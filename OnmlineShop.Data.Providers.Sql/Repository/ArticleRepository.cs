using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Core.Models;
using OnlineShop.Data.Providers.Sql.Models;
using System;
using AutoMapper;

namespace OnlineShop.Data.Providers.Sql.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private OnlineShopDbContext context;
        private IMapper mapper;
        public ArticleRepository(OnlineShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ArticleCore>> GetAllAsync()
        {
            return this.mapper.Map<IEnumerable<ArticleCore>>
                (await this.context.Articles.AsNoTracking().ToListAsync());
        }

        public async Task<ArticleCore> GetByIdAsync(int id)
        {
            return this.mapper.Map<ArticleCore>
                (await this.context.Articles.AsNoTracking().Include(a=>a.Categories).FirstOrDefaultAsync(u => u.Id == id));
        }

        public async Task<ArticleCore> CreateAsync(ArticleCore articleCore)
        {
            if (articleCore != null)
            {
                this.context.Articles.Add(this.mapper.Map<Article>(articleCore));
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Entity not found");
            }
            return articleCore;
        }
        public async Task DeleteAsync(int articleId)
        {
            var articleDb = await this.context.Articles.FindAsync(articleId);
            if (articleDb == null)
            {
                throw new Exception("Entity not Found");
            }
            this.context.Articles.Remove(articleDb);
            this.context.Entry(articleDb).State = EntityState.Deleted;
            await this.context.SaveChangesAsync();
        }

        public async Task<ArticleCore> UpdateAsync(ArticleCore articleCore)
        {
            var article = await this.GetByIdAsync(articleCore.Id);
            if (article == null)
            {
                throw new Exception("Entity not found.");
            }
            var articleData = this.mapper.Map<Article>(articleCore);
            this.context.Articles.Attach(articleData);
            this.context.Entry(articleData).State = EntityState.Modified;
            await this.context.SaveChangesAsync();

            return articleCore;
        }

        public async Task<IEnumerable<CategoryCore>> getAllCategoriesAsync()
        {
            return this.mapper.Map<IEnumerable<CategoryCore>>(await this.context.Categories.AsNoTracking().ToListAsync());
        }
    }
}
