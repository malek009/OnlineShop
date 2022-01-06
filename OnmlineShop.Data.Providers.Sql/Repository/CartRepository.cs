using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using OnlineShop.Data.Providers.Sql.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Data.Providers.Sql.Repository
{
    public class CartRepository : ICartRepository
    {
        private OnlineShopDbContext context;
        private IMapper mapper;
        public CartRepository(OnlineShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CartCore>> GetAllAsync()
        {
            return this.mapper.Map<IEnumerable<CartCore>>
                (await this.context.Carts.AsNoTracking().ToListAsync());
        }
        public async Task<CartCore> GetByIdAscy(int id)
        {
            return this.mapper.Map<CartCore>(await this.context.Carts.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id));
        }
        public async Task<CartCore> CreateAsync(CartCore cartCore)
        {
            if (cartCore != null)
            {
                
                var cartData = this.mapper.Map<Cart>(cartCore);
                cartCore.Id = cartData.Id;
                this.context.Carts.Add(cartData);
                await this.context.SaveChangesAsync();   
            }
            else
            {
                throw new Exception("Entity not found");
            }

            return cartCore;
        }
        public async Task DeleteAsync(int cartId)
        {
            var cartDb = await this.context.Carts.FindAsync(cartId);
            if (cartDb == null)
            {
                throw new Exception("Entity not Found");
            }
            this.context.Carts.Remove(cartDb);
            await this.context.SaveChangesAsync();
        }

        public async Task<CartCore> UpdateAsync(CartCore cartCore)
        {
            var cartDb = await this.GetByIdAscy(cartCore.Id);
            if(cartDb == null)
            {
                throw new Exception($"Le panier avec l'id :{cartCore.Id} n'exsiste pas");
            }else
            {
                var cartData = this.mapper.Map<Cart>(cartCore);
                this.context.Carts.Attach(cartData);
                this.context.Entry(cartData).State = EntityState.Modified;
                await this.context.SaveChangesAsync();
                return cartCore;
            }
        }
        public async Task<IEnumerable<CartCore>> GetAllIncludeAsync()
        {

            return this.mapper.Map<IEnumerable<CartCore>>
            (await this.context.Carts
                                     .AsNoTracking()
                                     .Include(c => c.CartArticles)
                                     .ToListAsync());
        }
    }
}
