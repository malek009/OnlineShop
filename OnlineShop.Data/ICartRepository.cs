using OnlineShop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public interface ICartRepository
    {
        public  Task<IEnumerable<CartCore>> GetAllAsync();
        public  Task<CartCore> GetByIdAscy(int id);
        public  Task<CartCore> CreateAsync(CartCore cartCore);
        public Task DeleteAsync(int cartId);
        public  Task<CartCore> UpdateAsync(CartCore cartCore);
        public  Task<IEnumerable<CartCore>> GetAllIncludeAsync();
    }
}
