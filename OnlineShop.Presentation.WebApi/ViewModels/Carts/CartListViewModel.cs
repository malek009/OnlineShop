using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Presentation.WebApi.ViewModels.Carts
{
    public class CartListViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        
        [JsonPropertyName("Price")]
        public double Price { get; set; }

        [JsonPropertyName("IsPaied")]
        public bool IsPaied { get; set; }
        
    }
}
