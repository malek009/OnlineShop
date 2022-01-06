using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.presentation.WebApp1.Models.Articles
{
    public class CategoryArticleViewModel
    {
        public int Id { get; set; }
        [Display(Name="Categories")]
        public string Name { get; set; }
    }
}
