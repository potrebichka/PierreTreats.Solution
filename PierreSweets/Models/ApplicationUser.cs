using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;


namespace PierreSweets.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Orders = new HashSet<Order>();
        }
        public virtual ICollection<Order> Orders { get; set; }
    }
}