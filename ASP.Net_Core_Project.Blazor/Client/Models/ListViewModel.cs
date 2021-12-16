using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ASP.Net_Core_Project.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("bookId")]
        public int BookId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
