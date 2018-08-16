using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BandPromotionPlatform.Models
{
    public class AdminUser
    {
        [Key]
        [Display(Name = "Admin ID")]
        public int AdminID { get; set; }
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}