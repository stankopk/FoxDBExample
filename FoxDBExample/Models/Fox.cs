using Microsoft.AspNetCore.Identity;

namespace FoxDBExample.Models
{
    public class Fox
    {
        public int Id { get; set; }

        //random code
        public string Name { get; set; }

        public int Age { get; set; }

        // Foreign key to IdentityUser
        public string UserId { get; set; }
        public IdentityUser User { get; set; } // Navigation property
    }
}
