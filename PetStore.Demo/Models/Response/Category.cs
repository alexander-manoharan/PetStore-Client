using System.Text.Json.Serialization;

namespace PetStore.Demo.Models 
{
    /// <summary>
    /// Represents the category of the Pet <see cref="Pet"/>
    /// </summary>
    public class Category 
    {
        /// <summary>
        /// Id of the Pet
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }
        /// <summary>
        /// Name of the Pet
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}