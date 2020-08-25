using System.Collections.Generic;

namespace PetStore.Demo.Models {
    class Pet {
        public long id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public List<string> photoUrls { get; set; }
        public List<Category> tags { get; set; }
        public string status { get; set; }

        public override string ToString() {
            if (category != null && category.name != null) {
                return "[category: " + category.name + " name: " + name + "]";
            } else {
                return "[category: (null) name: " + name + "]";
            }
        }
    }
}