using System.Collections;
using System.Collections.Generic;

namespace OnlineShop.Core.Models
{
    public class UserCore
    {
        public int Id { get; set; }
        public string FirstNameCore { get; set; }
        public string LastNameCore { get; set; }
        public string Address { get; set; }
        public ICollection<CartCore> Carts { get; set; }

        public ICollection<CartArticleCore> CartArticle { get; set; }
    }
}
