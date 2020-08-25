using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using PetStore.Demo.Models;

namespace PetStore.Demo
{
    class Client
    {
        const string BaseAddress = "https://petstore.swagger.io/v2/";
        const string InventoryPath = "store/inventory";
        const string GetPetsPath = "pet/findByStatus";
        const string ApplicationJson = "application/json";
        const string StatusAvailable = "available";

        HttpClient httpClient = new HttpClient();

        public Client() {
            httpClient.BaseAddress = new Uri(BaseAddress);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(ApplicationJson));
        }

        private static List<Pet> SortPets(List<Pet> pets) {
            return pets.OrderBy(pet => pet.category == null ? "" : pet.category.name).
                        ThenByDescending(pet => pet.name).ToList();
        }

        public async Task<Inventory> GetInventory() {
            Inventory inventory = null;
            HttpResponseMessage response = await httpClient.GetAsync(InventoryPath);
            if (response.IsSuccessStatusCode) {
                var responseAsString = await response.Content.ReadAsStringAsync();
                inventory = JsonSerializer.Deserialize<Inventory>(responseAsString);
            } else {
                Console.WriteLine("GetInventory Failure");
                Console.Write(await response.Content.ReadAsStringAsync());
            }
            return inventory;
        }

        public Task<List<Pet>> GetAvailablePets() {
            return GetPetsByStatus(GetPetsPath, StatusAvailable);
        }

        private async Task<List<Pet>> GetPetsByStatus(string path, string availability) {
            List<Pet> pets = new List<Pet>();
            List<Pet> sortedPets = new List<Pet>();

            HttpResponseMessage response = await httpClient.GetAsync(GetPetsPath + "?status=" + availability);
            if (response.IsSuccessStatusCode) {
                var responseAsString = await response.Content.ReadAsStringAsync();
                pets = JsonSerializer.Deserialize<List<Pet>>(responseAsString);
                sortedPets = SortPets(pets);
                return sortedPets;
            } else {
                Console.WriteLine("GetPetsByStatus Failure");
                return null;
            }
        }
    }
}
