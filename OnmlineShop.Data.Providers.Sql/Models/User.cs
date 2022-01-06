using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data.Providers.Sql.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; }   
        public string Address { get; set; }
        public IEnumerable<Cart> Carts { get; set; }

        
    }
}
