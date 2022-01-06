using OnlineShop.Core.Models;
using OnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Business
{
    public class ArticleDomain
    {
        private readonly IArticleRepository articleRepository;

        public ArticleDomain(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async Task<IEnumerable<ArticleCore>> GetAllAsync()
        {
            return await this.articleRepository.GetAllAsync();
        }

        public async Task<ArticleCore> GetByIdAsync(int articleId)
        {
            return await this.articleRepository.GetByIdAsync(articleId);
        }
        public async Task<ArticleCore> CreateAsync(ArticleCore articleCore)
        {
            return await this.articleRepository.CreateAsync(articleCore);
        }
        public async Task DeleteAsync(int articleId)
        {
            await this.articleRepository.DeleteAsync(articleId);
        }
        public async Task<ArticleCore> UpdateAsync(ArticleCore articleCore)
        {
            return await this.articleRepository.UpdateAsync(articleCore);
        }

        public async Task<IEnumerable<CategoryCore>> getAllCategoriesAsync()
        {
            return await this.articleRepository.getAllCategoriesAsync();
        }
    }
}
