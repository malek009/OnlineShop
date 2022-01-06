using OnlineShop.Core.Models;
using OnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
namespace OnlineShop.Business
{
    public class CartDomain
    {
        private readonly ICartRepository cartRepository;
        private readonly IArticleRepository articleRepository;
        private readonly ICartArticlesRepository cartArticleRepository;
        public CartDomain(ICartRepository cartRepository, IArticleRepository articleRepository,
                          ICartArticlesRepository cartArticleRepository)
        {
            this.cartRepository = cartRepository;
            this.articleRepository = articleRepository;
            this.cartArticleRepository = cartArticleRepository;
        }
        public async Task<IEnumerable<CartCore>> GetAllAsync()
        {
            return await this.cartRepository.GetAllAsync();
        }
        public async Task<CartCore> GetByIdAscy(int Id)
        {
            return await this.cartRepository.GetByIdAscy(Id);
        }

        public async Task<CartCore>CreateAsync(CartCore cartCore)
        {   
            using (var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await this.cartRepository.CreateAsync(cartCore);
                tx.Complete();
            }
            return cartCore;
        }

        public async Task<CartCore> AddArticleToCartAsync(CartArticleCore cartArticle)
        {
            var cartCoreFromDb = await this.cartRepository.GetByIdAscy(cartArticle.CartId);
            if(cartCoreFromDb == null)
            {
                throw new Exception("Cart not found");
            }
            var articleCoreFromDb = await this.articleRepository.GetByIdAsync(cartArticle.ArticleId);
            if(articleCoreFromDb == null)
            {
                throw new Exception("Article not found");
            }
            
            if (articleCoreFromDb.Stock > cartArticle.Amount)
            {
                articleCoreFromDb.Stock -= cartArticle.Amount;

                cartCoreFromDb.Price += articleCoreFromDb.Price * cartArticle.Amount;
                using (var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await this.cartRepository.UpdateAsync(cartCoreFromDb);
                    await this.articleRepository.UpdateAsync(articleCoreFromDb);
                    await this.cartArticleRepository.SaveCartArticle(cartArticle);
                    tx.Complete();
                    tx.Dispose();
                }
            }else
            {
                throw new Exception("stok problem");
            }
            return cartCoreFromDb;
        }

        public async Task<IEnumerable<CartCore>> GetAllIncludeAsync()
        {
            var cartCoreList = await this.cartRepository.GetAllIncludeAsync();   
            return cartCoreList;
        }

        public async Task DeleteAsync(int cartId)
        {
            using (var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            { 
                await this.cartRepository.DeleteAsync(cartId);
                tx.Complete();
            }
        }
    }
}
