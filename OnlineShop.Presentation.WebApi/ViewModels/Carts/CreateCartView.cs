using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Presentation.WebApi.Models
{
    public class CreateCartView
    {
        
        [JsonPropertyName("DateCreation")]
        public DateTime DateCreation { get; set; }
        [JsonPropertyName("DatePaied")]
        public DateTime DatePaied { get; set; }

        [JsonPropertyName("Price")]
        public double Price { get; set; }

        [JsonPropertyName("IsPaied")]
        public bool IsPaied { get; set; }
        [JsonPropertyName("UserId")]
        public int UserId { get; set; }
        [JsonIgnore]
        public UserCore UserCore { get; set; }
    }
}
