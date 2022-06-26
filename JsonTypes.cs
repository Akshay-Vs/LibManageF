using Newtonsoft.Json;
using System;


namespace Library_Management_System
{
    
        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public class TypeBook
        {
            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("Author")]
            public string Author { get; set; }

            [JsonProperty("Publisher")]
            public string Publisher { get; set; }

            [JsonProperty("Price")]
            public string Price { get; set; }

            [JsonProperty("Pages")]
            public string Pages { get; set; }

            [JsonProperty("Availability")]
            public string Availability { get; set; }
    }
    
}
