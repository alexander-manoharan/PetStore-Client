using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Demo.Interfaces;
using PetStore.Demo.Models;
using PetStore.Demo.Serices;

namespace PetStore.Demo.Providers
{
    public class PetStoreService : IPetStoreService
    {
        private readonly IPetStoreRepository _Repository;

        public PetStoreService(IPetStoreRepository repository)
        {
            _Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Inventory> GetInventoryAsync()
        {
            Inventory inventory = await _Repository.GetInventory();
            return inventory;
        }

        public async Task<IEnumerable<Pet>> GetPetsByCategoryAsync(Status status)
        {
            IEnumerable<Pet> pets = await _Repository.GetPetsByStatus(status);
            // Remove null category, order by category and then order name by descending
            return pets.Where(pet => pet.Category != null)
                        .OrderBy(pet => pet.Category.Name)
                        .ThenByDescending(pet => pet.Name)
                        .ToList();
        }
    }
}