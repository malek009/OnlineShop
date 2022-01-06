using OnlineShop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public interface IUserRepository
    { 
        public  Task<IEnumerable<UserCore>> GetAllAsync();
        public  Task<UserCore> GetByIdAsync(int id);
        public  Task<UserCore> CreateAsync(UserCore userCore);
        public  Task DeleteAsync(int userId);
        public  Task<UserCore> UpdateAsync(UserCore userCore);
        public  Task<IEnumerable<UserCore>> GetByParametersAsync(UserCore userCore);
        public  Task<IEnumerable<UserCore>> GetAllIncludeAsync();

        public Task<UserCore> GetByIdIncludeAsync(int id);

    }
}
