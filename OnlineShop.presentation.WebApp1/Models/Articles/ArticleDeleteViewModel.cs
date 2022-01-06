using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.presentation.WebApp1.Models.Articles
{
    public class ArticleDeleteViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nom :")]
        public string Name { get; set; }
        [Display(Name = "Reference :")]
        public string Refe { get; set; }
    }
}
