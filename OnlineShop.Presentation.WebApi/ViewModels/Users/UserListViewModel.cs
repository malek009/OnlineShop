using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Presentation.WebApi.ViewModels.Users
{
    public class UserListViewModel
    {
        [JsonPropertyName("Id")]
        public int  Id { get; set; }
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Address")]
        public string Address { get; set; }


    }
}
