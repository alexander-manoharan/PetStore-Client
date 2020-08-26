using System.Text.Json.Serialization;

namespace PetStore.Demo.Models {
    /// <summary>
    /// Inventory of the PetStore
    /// </summary>
    public class Inventory 
    {
        /// <summary>
        /// Sold Pets in PetStore
        /// </summary>
        [JsonPropertyName("sold")]
        public int Sold { get; set; }
        /// <summary>
        /// Unavailable Pets in PetStore
        /// </summary>
        [JsonPropertyName("nonAvailable")]
        public int NotAvailable { get; set; }
        /// <summary>
        /// Pending Pets in PetStore
        /// </summary>
        [JsonPropertyName("Pending")]
        public int Pending { get; set; }
        /// <summary>
        /// Available Pets in PetStore
        /// </summary>
        [JsonPropertyName("available")]
        public int Available { get; set; }
    }
}