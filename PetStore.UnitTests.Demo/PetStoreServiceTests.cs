using NSubstitute;
using NUnit.Framework;
using PetStore.Demo.Interfaces;
using PetStore.Demo.Models;
using PetStore.Demo.Providers;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.UnitTests.Demo
{
    public class Tests
    {

        [Test]
        public void GetInventoryTest()
        {
            var repository = Substitute.For<IPetStoreRepository>();
            repository.GetInventory().Returns(
                GetMockInventory(100, 5, 256, 9)
            );

            var service = new PetStoreService(repository);
            var result = service.GetInventoryAsync().Result;

            Assert.That(result.Available == 256);
            Assert.That(result.Sold == 100);
            Assert.That(result.NotAvailable == 5);
            Assert.That(result.Pending == 9);
        }

        [Test]
        public void EnsurePetsAreReturnedTest()
        {
            var repository = Substitute.For<IPetStoreRepository>();
            repository.GetPetsByStatus(Status.Available).Returns(
                new List<Pet>
                {
                    GetMockPet("Pet1", 23, "Category1"),
                    GetMockPet("Pet2", 43, "Category2")
                }
            );

            var service = new PetStoreService(repository);
            var result = service.GetPetsByCategoryAsync(Status.Available).Result;

            var results = result.ToList();
            Assert.That(results.Count == 2);
        }

        [Test]
        public void EnsureNullPetsAreFilteredTest()
        {
            var repository = Substitute.For<IPetStoreRepository>();
            repository.GetPetsByStatus(Status.Available).Returns(
                new List<Pet>
                {
                    GetMockPet("Pet1", 23, "Category1"),
                    GetMockPet("Pet2"),
                    GetMockPet("Pet2", 43, "Category2"),
                }
            );

            var service = new PetStoreService(repository);
            var result = service.GetPetsByCategoryAsync(Status.Available).Result;

            var results = result.ToList();
            Assert.That(results.Count == 2);
        }

        private Inventory GetMockInventory(int sold, int notAvailable, int available, int pending)
        {
            return new Inventory
            {
                Sold = sold,
                NotAvailable = notAvailable,
                Available = available,
                Pending = pending
            };
        }

        private Pet GetMockPet(string name, long categoryId, string categoryName)
        {
            return new Pet
            {
                Name = name,
                Category = new Category
                {
                    Id = categoryId,
                    Name = categoryName
                }
            };
        }

        private Pet GetMockPet(string name, Category category = null)
        {
            return new Pet
            {
                Name = name,
                Category = category
            };
        }
    }
}