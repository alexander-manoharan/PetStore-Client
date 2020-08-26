using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Demo.Models;

namespace PetStore.Demo.Interfaces 
{
    /// <summary>
    /// PetStore repository. Represents the API from https://petstore.swagger.io/#/
    /// </summary>
    public interface IPetStoreRepository
    {
        /// <summary>
        /// Get Inventory from the PetStore
        /// </summary>
        /// <returns>Returns the available, pending and sold Pets from PetStore</returns>
        public Task<Inventory> GetInventory();
        /// <summary>
        /// Get Pets by status <see cref="Status"/>
        /// </summary>
        /// <param name="status">Status from <see cref="Status"/></param>
        /// <returns>Returns the list of Pets by requested Status</returns>
        public Task<IEnumerable<Pet>> GetPetsByStatus(Status status);
    }
}