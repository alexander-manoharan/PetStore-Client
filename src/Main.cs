using System;
using System.Threading.Tasks;
using PetStore;

namespace MainProgram {
    class PetStoreDemo {
        public static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync() {
            try {
                var client = new Client();
                var inventory = await client.GetInventory();
                var pets = await client.GetAvailablePets();
                foreach(var pet in pets) {
                    Console.WriteLine(pet.ToString());
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}