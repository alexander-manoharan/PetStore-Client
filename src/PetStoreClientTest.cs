using System.Collections.Generic;
using System.Linq;
using PetStore.Demo;
using PetStore.Demo.Models;
using Xunit;

public class PetStoreClientTest {
    Client client = new Client();

    [Fact]
    public async void NumberOfPetsTest() {
        List<Pet> pets = (await client.GetAvailablePets()).ToList();
        var inventory = await client.GetInventory();
        Assert.Equal(inventory.Available, pets.Count);
    }

    [Fact]
    public async void SortedPetsTest() {
        var pets = await client.GetAvailablePets();
        Assert.NotEmpty(pets);

        var sortedPets = pets.OrderBy(pet => pet.Category == null ? "" : pet.Category.Name).
                        ThenByDescending(pet => pet.Name).ToList();
        Assert.Equal(sortedPets, pets);
    }
}