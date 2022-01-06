using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Providers.Sql.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.presentation.WebApp1.Models.Articles
{
    public class ArticleDetailsViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [Display(Name="Nom :")]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Reference :")]
        public string Refe { get; set; }
        
        [Display(Name = "Description :")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Stock :")]
        public int Stock { get; set; }
        [Required]
        [Display(Name = "Prix :")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Image :")]
        public string image { get; set; }
        /*[Display(Name="Date de creation :")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [Display(Name="oui ou non")]
        public bool IsYesOrNo { get; set; }
        [Display(Name = "Categories :")]*/
        
        public CategoryArticleViewModel CategoriesModel { get; set; }

        [Display(Name = "Categorie :")]
        public CategoryArticleViewModel Categories { get; set; }
    }
}
