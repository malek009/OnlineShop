using AutoMapper;
using OnlineShop.Core.Models;
using OnlineShop.Presentation.WebApi.Models;
using OnlineShop.Presentation.WebApi.ViewModels.Articles;
using OnlineShop.Presentation.WebApi.ViewModels.CartsArticles;
using OnlineShop.Presentation.WebApi.ViewModels.Users;


namespace OnlineShop.Presentation.WebApi.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            
           
            this.CreateMap<UserUpdateViewModel, UserCore>()
                .ForMember(dest => dest.FirstNameCore, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastNameCore, opt => opt.MapFrom(src => src.LastName))
                .ReverseMap();
            this.CreateMap<UserViewModel, UserCore>()
                .ForMember(dest => dest.FirstNameCore, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastNameCore, opt => opt.MapFrom(src => src.LastName))
                .ReverseMap();

            this.CreateMap<UserListViewModel,UserCore >()
                .ForMember(dest => dest.FirstNameCore, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastNameCore, opt => opt.MapFrom(src => src.LastName))
                .ReverseMap();

               

            this.CreateMap<ArticleListViewModel, ArticleCore>().ReverseMap();
            this.CreateMap<ArticleViewModel, ArticleCore>().ReverseMap();
            this.CreateMap<ArticleUpdateViewModel, ArticleCore>().ReverseMap();
            
       
            
            this.CreateMap<CartArticleListVieuwModel, CartArticleCore>().ReverseMap();
            this.CreateMap<CartArticleViewModel, CartArticleCore>().ReverseMap();
        }
    }
}
