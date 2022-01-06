using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Providers.Sql.Models
{   
    [Table("CartArticles")]
    public class CartArticles
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Cart")]
        public int CartId  { get; set; }
        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public int Amount { get; set; }
    }
}
