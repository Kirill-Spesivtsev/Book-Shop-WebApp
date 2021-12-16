using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } 

        [JsonPropertyName("description")]
        public string Description { get; set; } 

        [JsonPropertyName("pages")]
        public int Pages { get; set; } 

        [JsonPropertyName("imageName")]
        public string ImageName { get; set; } 
    }
}
