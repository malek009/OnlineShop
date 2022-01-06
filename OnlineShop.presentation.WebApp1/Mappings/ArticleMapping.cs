using AutoMapper;
using OnlineShop.Core.Models;
using OnlineShop.presentation.WebApp1.Models.Articles;

namespace OnlineShop.presentation.WebApp1.Mappings
{
    public class ArticleMapping : Profile
    {
        public ArticleMapping()
        {
            this.CreateMap<ArticleCore, ArticleListViewModel>().ReverseMap();
            this.CreateMap<ArticleCore, ArticleDetailsViewModel>().ReverseMap();
            this.CreateMap<CategoryCore, CategoryArticleViewModel>().ReverseMap();
            this.CreateMap<ArticleFormViewModel, ArticleDetailsViewModel>().ReverseMap();
            this.CreateMap<ArticleCore, ArticleDeleteViewModel>().ReverseMap();

        }

    }
}
