using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.presentation.WebApp1.Models.Users
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Prenom :")]
        public string FirstNameCore { get; set; }
        [Display(Name = "Nom :")]
        public string LastNameCore { get; set; }
        [Display(Name = "Adresse :")]
        public string Address { get; set; }
        [Display(Name = "Carts :")]
        public ICollection<CartCore> Carts { get; set; }
        [Display(Name = "ArticleCarts :")]
        public ICollection<CartArticleCore> ArticleCarts { get; set; }
    }
}
