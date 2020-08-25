using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Demo.Models;

namespace PetStore.Demo.Serices
{
    public interface IPetStoreService
    {
        Task<Inventory> GetInventoryAsync();
        Task<IEnumerable<Pet>> GetPetsByCategoryAsync(Status status);
    }
}