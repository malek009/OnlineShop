using System;
using System.Collections.Generic;
namespace OnlineShop.Core.Models
{
    public class CartCore
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DatePaied { get; set; }
        public double Price { get; set; }
        public bool IsPaied { get; set; }
        public int UserId { get; set; }
        
        public UserCore Usercore { get; set; }
        public IEnumerable<CartArticleCore> CartArticles { get; set; }
    }
}
