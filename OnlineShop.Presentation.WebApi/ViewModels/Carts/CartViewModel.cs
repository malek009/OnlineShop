using OnlineShop.Presentation.WebApi.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Presentation.WebApi.ViewModels.Carts
{
    public class CartViewModel
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
        
    }
}
