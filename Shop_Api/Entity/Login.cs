using System.ComponentModel.DataAnnotations;

namespace Shop_Api.Entity
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
