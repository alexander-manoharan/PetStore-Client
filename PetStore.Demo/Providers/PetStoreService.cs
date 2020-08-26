using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Demo.Interfaces;
using PetStore.Demo.Models;
using PetStore.Demo.Serices;

namespace PetStore.Demo.Providers
{
    /// <summary>
    /// Implementation of <see cref="IPetStoreService"/>. Console application uses
    /// this class to fetch data from the PetStore. The repository is abstracted 
    /// inside the PetStore service.
    /// </summary>
    public class PetStoreService : IPetStoreService
    {
        /// <summary>
        /// Stores a reference to the Repository instance.
        /// </summary>
        private readonly IPetStoreRepository _Repository;

        public PetStoreService(IPetStoreRepository repository)
        {
            _Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Returns the current inventory status in the PetStore
        /// </summary>
        /// <returns></returns>
        public async Task<Inventory> GetInventoryAsync()
        {
            Inventory inventory = await _Repository.GetInventory();
            return inventory;
        }

        /// <summary>
        /// Get Pets by required <see cref="Status"/>, ordered by category and 
        /// arranged in descending order by name
        /// </summary>
        /// <param name="status">Status of the Pet in PetStore</param>
        /// <returns>Returns list of <see cref="Pet"/> requested by status</returns>
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