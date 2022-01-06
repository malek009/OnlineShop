using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.presentation.WebApp1.Models.Articles
{
    public class ArticleFormViewModel
    {
        public ArticleDetailsViewModel Article { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
