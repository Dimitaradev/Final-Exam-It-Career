using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CoolEvents_Final_IT_Career.Models
{
    public class Users : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set;}

        //public virtual ICollection<Orders> Orders { get; set; }
    }
}
