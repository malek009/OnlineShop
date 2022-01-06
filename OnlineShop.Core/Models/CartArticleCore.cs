

namespace OnlineShop.Core.Models
{
    public class CartArticleCore
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ArticleId { get; set; }
        public int Amount { get; set; }
    }
}
