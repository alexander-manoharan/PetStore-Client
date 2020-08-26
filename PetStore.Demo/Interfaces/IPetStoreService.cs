using System.Collections.Generic;
using System.Threading.Tasks;
using PetStore.Demo.Models;

namespace PetStore.Demo.Serices
{
    /// <summary>
    /// Interface for PetStore Service
    /// </summary>
    public interface IPetStoreService
    {
        /// <summary>
        /// Get current inventory from PetStore asynchronously
        /// </summary>
        /// <returns>Returns current inventory of PetStore</returns>
        Task<Inventory> GetInventoryAsync();
        /// <summary>
        /// Get Pets by required status ordered by Category and sorted in reverse
        /// order of name.
        /// </summary>
        /// <param name="status">Required status of the Pet <see cref="Status"/></param>
        /// <returns>Returns a list of Pet</returns>
        Task<IEnumerable<Pet>> GetPetsByCategoryAsync(Status status);
    }
}