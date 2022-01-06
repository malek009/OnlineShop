namespace OnlineShop.Core.Models
{
    public class ArticleCore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Refe { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public string  image { get; set; }
        public int CategoryId { get; set; }

        public CategoryCore Categories { get; set; }
    }
}
