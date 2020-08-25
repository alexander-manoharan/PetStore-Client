using System.Linq;
using PetStore.Demo;
using Xunit;

public class PetStoreClientTest {
    Client client = new Client();

    [Fact]
    public async void NumberOfPetsTest() {
        var pets = await client.GetAvailablePets();
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