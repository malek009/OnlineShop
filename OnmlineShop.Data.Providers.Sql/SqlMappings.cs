using AutoMapper;
using OnlineShop.Core.Models;
using OnlineShop.Data.Providers.Sql.Models;

namespace OnlineShop.Data.Providers.Sql
{
    public class SqlMappings : Profile
    {
        public SqlMappings()
        {
            this.CreateMap<User, UserCore>()
                .ForMember(dest => dest.FirstNameCore, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastNameCore, opt => opt.MapFrom(src => src.LastName))
                .ReverseMap();
            this.CreateMap<UserCore, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstNameCore))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastNameCore))
                .ReverseMap();
            this.CreateMap<Article, ArticleCore>().ReverseMap();
            this.CreateMap<Cart, CartCore>().ReverseMap();
            this.CreateMap<CartArticles, CartArticleCore>().ReverseMap();

            this.CreateMap<Category, CategoryCore>().ReverseMap();
          

            
        }
    }
}
