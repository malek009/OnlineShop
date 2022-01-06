using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Presentation.WebApi.ViewModels.CartsArticles
{
    public class CartArticleListVieuwModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("CartId")]
        public int CartId { get; set; }
        [JsonPropertyName("ArticleId")]
        public int ArticleId { get; set; }
        [JsonPropertyName("Amount")]
        public int Amount { get; set; }
    }
}
