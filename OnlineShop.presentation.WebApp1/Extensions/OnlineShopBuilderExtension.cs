using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Business;
using OnlineShop.Data;
using OnlineShop.Data.Providers.Sql.Models;
using OnlineShop.Data.Providers.Sql.Repository;


namespace OnlineShop.presentation.WebApp1.Extensions
{
    public static class OnlineShopBuilderExtension
    {
        public static void AddRepository(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IArticleRepository,ArticleRepository>();
            service.AddScoped<ICartRepository,CartRepository>();
            service.AddScoped<ICartArticlesRepository, CartArticleRepository>();
        }
        public static void AddDomain(this IServiceCollection service)
        {
            service.AddScoped<CartDomain>();
            service.AddScoped<UserDomain>();
            service.AddScoped<ArticleDomain>();
            service.AddScoped<CartArticlesDomain>();
        }

    }
}
