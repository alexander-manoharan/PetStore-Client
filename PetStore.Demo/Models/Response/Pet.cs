using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PetStore.Demo.Models {
    /// <summary>
    /// Representation of Pet class from PetStore
    /// </summary>
    public class Pet {
        /// <summary>
        /// Id of the Pet
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }
        /// <summary>
        /// Category of the Pet (name and id)
        /// </summary>
        [JsonPropertyName("category")]
        public Category Category { get; set; }
        /// <summary>
        /// Name of the Pet
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// Photo URLs of the Pet
        /// </summary>
        [JsonPropertyName("photoUrls")]
        public IEnumerable<string> PhotoUrls { get; set; }
        /// <summary>
        /// Tag strings of the Pet
        /// </summary>
        [JsonPropertyName("tags")]
        public IEnumerable<Category> Tags { get; set; }
        /// <summary>
        /// Status of the Pet <see cref="Status"/>
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}