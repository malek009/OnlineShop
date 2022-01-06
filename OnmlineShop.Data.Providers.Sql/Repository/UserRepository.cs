using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Providers.Sql.Models
{
    public class UserRepository : IUserRepository
    {
        private OnlineShopDbContext context;
        private IMapper mapper;
        public UserRepository(OnlineShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UserCore>> GetAllAsync()
        {
            return this.mapper.Map<IEnumerable<UserCore>>
                (await this.context.Users.AsNoTracking().ToListAsync());
        }
       
        public async Task<UserCore>GetByIdAsync(int  id)
        {
            return this.mapper.Map<UserCore>(await this.context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id==id));
        }

        public async Task<UserCore> GetByIdIncludeAsync(int id)
        {
            var include = this.GetAllIncludeAsync();
            UserCore userCore = null;
             foreach(UserCore item in  include.Result.ToList() )
            {
                if(item.Id == id)
                {
                    userCore =   item;
                }
            }
            return  userCore;
        }
        public async Task<UserCore> CreateAsync(UserCore userCore)
        {
            if(userCore != null)
            {
                var userDb = this.mapper.Map<User>(userCore);
                this.context.Users.Add(userDb);
                await this.context.SaveChangesAsync();
                userCore.Id = userDb.Id;
            }
            else
            {
                throw new Exception("Entity not found");
            }
            
            return userCore;
        }
        public async Task DeleteAsync(int userId)
        {
            var userDb = await this.context.Users.FindAsync(userId);
            if(userDb == null)
            {
                throw new Exception("Entity not Found");
            }
            this.context.Users.Remove(userDb);
            await this.context.SaveChangesAsync();
        }
        public async Task<UserCore> UpdateAsync(UserCore userCore)
        {
            var userDb = await this.GetByIdAsync(userCore.Id);
            if (userDb == null)
            {
                throw new Exception("Entity not found.");
            }
            
            var userData = this.mapper.Map<User>(userCore);
            this.context.Users.Attach(userData);
            this.context.Entry(userData).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            
            return userCore;
        }
        public async Task<IEnumerable<UserCore>> GetByParametersAsync(UserCore userCore)
        {
            var usersTmp = this.context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(userCore.FirstNameCore))
            {
                usersTmp = usersTmp.Where(m => m.FirstName.Contains(userCore.FirstNameCore));
            }
            if (!string.IsNullOrEmpty(userCore.LastNameCore))
            {
                usersTmp = usersTmp.Where(m => m.LastName.Contains(userCore.LastNameCore));
            }
            if (!string.IsNullOrEmpty(userCore.Address))
            {
                usersTmp = usersTmp.Where(m => m.Address.Contains(userCore.Address));
            }

            var userList = await usersTmp.ToListAsync();
            return this.mapper.Map<IEnumerable<UserCore>>(userList);
        }
        public async Task<IEnumerable<UserCore>> GetAllIncludeAsync()
        {
            return this.mapper.Map<IEnumerable<UserCore>>
            (await this.context.Users
                                     .AsNoTracking()
                                     .Include(c => c.Carts).ThenInclude(m => m.CartArticles)
                                     .ToListAsync());
        }
    }
}
