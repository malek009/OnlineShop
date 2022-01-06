using OnlineShop.Core.Models;
using OnlineShop.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Business
{
    public class CartArticlesDomain
    {
        private readonly ICartArticlesRepository cartArticleRepository;

        public CartArticlesDomain(ICartArticlesRepository cartArticleRepository)
        {
            this.cartArticleRepository = cartArticleRepository;
        }

        public async Task<IEnumerable<CartArticleCore>> GetAllAsync()
        {
            return await this.cartArticleRepository.GetAllAsync();
        }

        public async Task<CartArticleCore> GetByIdAsync(int cartArticleID)
        {
            return await this.cartArticleRepository.GetByIdAsync(cartArticleID);
        }
        public async Task<CartArticleCore> CreateAsync(CartArticleCore cartArticleCore)
        {
            return await this.cartArticleRepository.CreateAsync(cartArticleCore);
        }

        public async Task DeleteAsync(int cartArticleID)
        {
            await this.cartArticleRepository.DeleteAsync(cartArticleID);
        }

    }
}
