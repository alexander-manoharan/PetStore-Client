using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Demo.Models;
using PetStore.Demo.Serices;

namespace PetStore.Demo.Providers
{
    public class PetStoreService : IPetStoreService
    {
        Task<IEnumerable<Pet>> IPetStoreService.GetPetsByCategoryAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}