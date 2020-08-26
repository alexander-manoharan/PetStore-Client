using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using PetStore.Demo.Interfaces;
using PetStore.Demo.Models;

namespace PetStore.Demo.Providers
{
    public class PetStoreRepository : IPetStoreRepository
    {
        const string BaseAddress = "https://petstore.swagger.io/v2";
        const string InventoryPath = "store/inventory";
        const string GetPetsPath = "pet/findByStatus";
        const string ApplicationJson = "application/json";

        private readonly HttpClient _HttpClient;

        public PetStoreRepository()
        {
            _HttpClient = new HttpClient();
            _HttpClient.BaseAddress = new Uri(BaseAddress);
            _HttpClient.DefaultRequestHeaders.Accept.Clear();
            _HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(ApplicationJson));
        }

        public async Task<Inventory> GetInventory()
        {
            string urlPath = $"{BaseAddress}/{InventoryPath}";
            HttpResponseMessage response = await _HttpClient.GetAsync(urlPath);
            if (response.IsSuccessStatusCode)
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Inventory>(responseAsString);
            }
            else
            {
                Console.WriteLine(PetStoreResources.InventoryFailureMsg);
                return null;
            }
        }
        public async Task<IEnumerable<Pet>> GetPetsByStatus(Status status)
        {
            string urlPath = $"{BaseAddress}/{GetPetsPath}?status={status.ToString().ToLowerInvariant()}";
            HttpResponseMessage response = await _HttpClient.GetAsync(urlPath);
            if (response.IsSuccessStatusCode) 
            {
                var responseAsString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<Pet>>(responseAsString);
            } 
            else 
            {
                Console.WriteLine(PetStoreResources.GetPetFailureMsg);
                return null;
            }
        }
    }
}