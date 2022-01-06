using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using OnlineShop.Data.Providers.Sql.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Data.Providers.Sql.Repository
{
    public class CartArticleRepository : ICartArticlesRepository
    {
        private OnlineShopDbContext context;
        private IMapper mapper;
        public CartArticleRepository(OnlineShopDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CartArticleCore>> GetAllAsync()
        {
            return this.mapper.Map<IEnumerable<CartArticleCore>>
                (await this.context.CartsArticles.AsNoTracking().ToListAsync());
        }
        public async Task<CartArticleCore> GetByIdAsync(int id)
        {
            return this.mapper.Map<CartArticleCore>
                (await this.context.CartsArticles.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id));
        }
        public async Task<CartArticleCore> CreateAsync(CartArticleCore cartArticleCore)
        {
            if (cartArticleCore != null)
            {
                this.context.CartsArticles.Add(this.mapper.Map<CartArticles>(cartArticleCore));
                await this.context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Entity not found");
            }
            return cartArticleCore;
        }
       
        public async Task DeleteAsync(int cartArticleId)
        {
            var cartArticleDb = await this.context.CartsArticles.FindAsync(cartArticleId);
            if (cartArticleDb == null)
            {
                throw new Exception("Entity not Found");
            }
            this.context.CartsArticles.Remove(cartArticleDb);
            this.context.Entry(cartArticleDb).State = EntityState.Deleted;
            await this.context.SaveChangesAsync();
        }
        public async Task SaveCartArticle(CartArticleCore cartArticleCore)
        {
            this.context.CartsArticles.Add(this.mapper.Map<CartArticles>(cartArticleCore));
            await this.context.SaveChangesAsync();
        }

    }
    
}
