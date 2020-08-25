using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PetStore.Demo.Models {
    public class Pet {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("category")]
        public Category Category { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("photoUrls")]
        public IEnumerable<string> PhotoUrls { get; set; }
        [JsonPropertyName("tags")]
        public IEnumerable<Category> Tags { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}