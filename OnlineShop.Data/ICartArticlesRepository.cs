using OnlineShop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public interface ICartArticlesRepository
    {
        public  Task<IEnumerable<CartArticleCore>> GetAllAsync();
        public  Task<CartArticleCore> GetByIdAsync(int id);
        public  Task<CartArticleCore> CreateAsync(CartArticleCore cartArticleCore);
        public  Task DeleteAsync(int cartArticleId);
        public  Task SaveCartArticle(CartArticleCore cartArticleCore);
    }
}
