using System.Linq;
using PetStore.Demo;
using Xunit;

public class PetStoreClientTest {
    Client client = new Client();

    [Fact]
    public async void NumberOfPetsTest() {
        var pets = await client.GetAvailablePets();
        var inventory = await client.GetInventory();
        Assert.Equal(inventory.available, pets.Count);
    }

    [Fact]
    public async void SortedPetsTest() {
        var pets = await client.GetAvailablePets();
        Assert.NotEmpty(pets);

        var sortedPets = pets.OrderBy(pet => pet.category == null ? "" : pet.category.name).
                        ThenByDescending(pet => pet.name).ToList();
        Assert.Equal(sortedPets, pets);
    }
}