using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetStore.Demo.Models;
using PetStore.Demo.Providers;
using PetStore.Demo.Serices;

namespace PetStore.Demo 
{
    class Program 
    {
        public static async Task Main(string[] args)
        {
            IPetStoreService petStoreService = new PetStoreService(new PetStoreRepository());
            try
            {
                IEnumerable<Pet> pets = await petStoreService.GetPetsByCategoryAsync(Status.Available);
                var listPets = pets.ToList();
                Console.WriteLine("Number of pets {0}", listPets.Count);

                foreach(Pet pet in listPets)
                {
                    Console.WriteLine("Category: {0} - Pet name: {1}", pet.Category.Name, pet.Name);
                }
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}