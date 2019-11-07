using BookingShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingShared.ViewModels
{
    public class SearchViewModel
    {
        [Required]
        [Display(Name = "Name", Prompt = "Hotel name")]
        public string Name { get; set; }
        [Display(Name = "Name", Prompt = "City")]
        public string City { get; set; }
        [Display(Name = "Stars", Prompt = "Stars")]
        [Range(1, 5)]
        public int Stars { get; set; }
        public List<HotelModel> Hotels { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public SearchViewModel()
        {
            Stars = 3;
            City = "Kazan";
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
        }
    }
}