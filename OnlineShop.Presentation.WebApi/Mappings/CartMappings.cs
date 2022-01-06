using AutoMapper;
using OnlineShop.Core.Models;
using OnlineShop.Presentation.WebApi.ViewModels.Carts;
using OnlineShop.Presentation.WebApi.ViewModels.CartsArticles;

namespace OnlineShop.Presentation.WebApi.Mappings
{
    public class CartMappings : Profile
    {
        public CartMappings()
        {
            this.CreateMap<CartCore, CartViewModel >().ReverseMap();
            this.CreateMap<CartCore , CartListViewModel>().ReverseMap();
            this.CreateMap<CartArticleCore, CartArticleViewModel>().ReverseMap();
        }
    }
}
