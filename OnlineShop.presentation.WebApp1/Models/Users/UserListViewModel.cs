

using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.presentation.WebApp1.Models.Users
{
    public class UserListViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string FirstNameCore { get; set; }
        public string LastNameCore { get; set; }
        public string Address { get; set; }
    }
}
