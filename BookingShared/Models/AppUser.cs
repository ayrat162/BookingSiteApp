using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingShared.Models
{
    public class AppUser : IdentityUser <int>
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "PassportNumber")]
        public string PassportNumber { get; set; }
    }
}
