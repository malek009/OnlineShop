using OnlineShop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public interface IArticleRepository
    {
        public Task<IEnumerable<ArticleCore>> GetAllAsync();
        public Task<ArticleCore> GetByIdAsync(int id);
        public Task<ArticleCore> CreateAsync(ArticleCore articleCore);
        public Task DeleteAsync(int articleId);
        public Task<ArticleCore> UpdateAsync(ArticleCore articleCore);
        Task<IEnumerable<CategoryCore>> getAllCategoriesAsync();
        
    }
}
