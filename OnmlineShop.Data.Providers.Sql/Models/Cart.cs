using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Providers.Sql.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DatePaied { get; set; }
        public double Price { get; set; }
        public bool IsPaied { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<CartArticles> CartArticles { get; set; }


    }
}
