using NSubstitute;
using NUnit.Framework;
using PetStore.Demo.Interfaces;
using PetStore.Demo.Models;
using PetStore.Demo.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.UnitTests.Demo
{
    public class Tests
    {

        /// <summary>
        /// Tests the inventory functionality of the PetStore
        /// </summary>
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

        /// <summary>
        /// Ensure if Pets are returned from PetStore query
        /// </summary>
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

        /// <summary>
        /// Ensure if Pets with null category are filtered out
        /// </summary>
        [Test]
        public void EnsureNullPetsAreFilteredTest()
        {
            var repository = Substitute.For<IPetStoreRepository>();
            repository.GetPetsByStatus(Status.Available).Returns(
                new List<Pet>
                {
                    GetMockPet("Pet1", 23, "Category1"),
                    GetMockPet("Pet2"),
                    GetMockPet("Pet3", 43, "Category2"),
                }
            );

            var service = new PetStoreService(repository);
            var result = service.GetPetsByCategoryAsync(Status.Available).Result;

            var results = result.ToList();
            Assert.That(results.Count == 2);
        }

        /// <summary>
        /// Ensure Pets are ordered by category (ascending) and Pet name (descending)
        /// </summary>
        [Test]
        public void EnsurePetsAreOrderedByCategoryTest()
        {
            var repository = Substitute.For<IPetStoreRepository>();
            repository.GetPetsByStatus(Status.Available).Returns(
                new List<Pet>
                {
                    GetMockPet("Pet1", 23, "Category2"),
                    GetMockPet("Pet2", 13, "Category1"),
                    GetMockPet("Pet3", 43, "Category2"),
                }
            );

            var service = new PetStoreService(repository);
            var result = service.GetPetsByCategoryAsync(Status.Available).Result;

            var results = result.ToList();
            // Ensure Pets are ordered by category in ascending order
            Assert.That(results[0].Category.Name.Equals("Category1"));
            Assert.That(results[1].Category.Name.Equals("Category2"));
            Assert.That(results[2].Category.Name.Equals("Category2"));

            Assert.That(results[1].Name.Equals("Pet3"));
            Assert.That(results[2].Name.Equals("Pet1"));
        }

        /// <summary>
        /// Returns a mock inventory object for API
        /// </summary>
        /// <param name="sold">Sold Pet count</param>
        /// <param name="notAvailable">Unavailable Pet count</param>
        /// <param name="available">Available Pet count</param>
        /// <param name="pending">Pending Pet count</param>
        /// <returns>Returns the requested Mock inventory object</returns>
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

        /// <summary>
        /// Get a mocked Pet object as requested
        /// </summary>
        /// <param name="name">Pet name</param>
        /// <param name="categoryId">Category Id</param>
        /// <param name="categoryName">Category Name</param>
        /// <returns>Returns the mocked Pet object</returns>
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

        /// <summary>
        /// Get a Mocked Pet object with specified / null category
        /// </summary>
        /// <param name="name">Pet name</param>
        /// <param name="category">Category object</param>
        /// <returns>Returns the mocked Pet object</returns>
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