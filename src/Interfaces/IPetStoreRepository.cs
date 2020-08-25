using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Demo.Models;

namespace PetStore.Demo.Interfaces 
{
    public interface IPetStoreRepository
    {
        public Task<Inventory> GetInventory();
        public Task<IEnumerable<Pet>> GetPetsByStatus(Status status);
    }
}