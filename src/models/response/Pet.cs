using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PetStore.Demo.Models {
    class Pet {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("category")]
        public Category Category { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("photoUrls")]
        public List<string> PhotoUrls { get; set; }
        [JsonPropertyName("tags")]
        public List<Category> Tags { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }

        public override string ToString() {
            if (Category != null && Category.Name != null) {
                return "[category: " + Category.Name + " name: " + Name + "]";
            } else {
                return "[category: (null) name: " + Name + "]";
            }
        }
    }
}