using AutoMapper;
using OnlineShop.Core.Models;
using OnlineShop.presentation.WebApp1.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.presentation.WebApp1.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            this.CreateMap<UserCore, UserListViewModel>().ReverseMap();
            this.CreateMap<UserCore, UserDetailsViewModel>().ReverseMap();
        }
    }
}
