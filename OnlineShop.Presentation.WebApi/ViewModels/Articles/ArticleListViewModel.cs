using System.Text.Json.Serialization;


namespace OnlineShop.Presentation.WebApi.ViewModels.Articles
{
    public class ArticleListViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Stock")]
        public int Stock { get; set; }
        [JsonPropertyName("Price")]
        public double Price { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("image")]
        public string image { get; set; }
    }
}
