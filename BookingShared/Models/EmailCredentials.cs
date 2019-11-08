using BookingShared.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingShared.Models
{
    public class EmailCredentials : IEmailCredentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
