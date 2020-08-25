using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Demo.Interfaces;
using PetStore.Demo.Models;

namespace PetStore.Demo.Providers
{
    class PetStoreRepository : IPetStoreRepository
    {
        public PetStoreRepository(string baseUrl)
        {

        }

        Task<IEnumerable<Pet>> IPetStoreRepository.GetPetsByStatus(Status status)
        {
            throw new System.NotImplementedException();
        }
    }
}