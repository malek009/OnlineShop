using System.Text.Json.Serialization;


namespace OnlineShop.Presentation.WebApi.Models
{
    public class UserUpdateViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Address")]
        public string Address { get; set; }
    }
}
