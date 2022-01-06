using OnlineShop.Core.Models;
using OnlineShop.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Business
{
    public class UserDomain
    {
        private readonly IUserRepository userRepository;
        private readonly ICartRepository cartRepository;

        public UserDomain(IUserRepository userRepository, ICartRepository cartRepository)
        {
            this.userRepository = userRepository;
            this.cartRepository = cartRepository;
        }
        
        public async Task<IEnumerable<UserCore>> GetAllAsync()
        {
            return await this.userRepository.GetAllAsync();
        }

        public async Task<UserCore> GetByIdAsync(int userId)
        {
            return await this.userRepository.GetByIdAsync(userId); 
        }
        public async Task<UserCore> CreateAsync(UserCore userCore)
        {
            return await this.userRepository.CreateAsync(userCore);
        }
        public async Task DeleteAsync(int userId)
        {
            await this.userRepository.DeleteAsync(userId);
        }
        public async Task<UserCore> UpdateAsync(UserCore userCore)
        {
            return await this.userRepository.UpdateAsync(userCore);
        }
        public async Task<IEnumerable<UserCore>> GetByParametersAsync(UserCore userCore)
        {
            return await this.userRepository.GetByParametersAsync(userCore);
        }
        public async Task<IEnumerable<UserCore>> GetAllIncludeAsync()
        {
            return await this.userRepository.GetAllIncludeAsync();
        }
        public async Task<UserCore> GetByIdIncludeAsync(int id)
        {
            return await this.userRepository.GetByIdIncludeAsync(id);

        }
            /* public async Task<CartCore> payCart()
         {
             cartCore.IsPaied = true;
             using (var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
             {
                 await this.cartRepository.UpdateAsync(cartCore);
                 tx.Complete();
                 tx.Dispose();
             }
             return cartCore;
         }*/

    }
}
