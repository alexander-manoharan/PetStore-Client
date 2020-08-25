using System.Text.Json.Serialization;

namespace PetStore.Demo.Models {
    class Inventory {
        [JsonPropertyName("sold")]
        public int Sold { get; set; }
        [JsonPropertyName("nonAvailable")]
        public int NotAvailable { get; set; }
        [JsonPropertyName("Pending")]
        public int Pending { get; set; }
        [JsonPropertyName("available")]
        public int Available { get; set; }
    }
}