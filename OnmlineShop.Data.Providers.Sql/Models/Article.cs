using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Providers.Sql.Models
{
    [Table("Article")]
    public class Article
    {
       [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }  
        public string Refe { get; set; }   
        public string Description { get; set; }     
        public int Stock { get; set; }
        public double Price { get; set; }
        public string  image { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Categories { get; set; }

    }
}
