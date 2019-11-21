using BookingShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookingShared.ViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "Name", Prompt = "Hotel name")]
        public string Name { get; set; }
        
        [Display(Name = "City", Prompt = "City")]
        public string City { get; set; }
        
        [Display(Name = "Stars", Prompt = "Stars")]
        [Range(1, 5)]
        public int Stars { get; set; }

        [Display(Name = "Begin Date", Prompt = "Begin Date")]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Begin Date", Prompt = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public List<HotelModel> Hotels { get; set; }
        
        public SearchViewModel()
        {
            Stars = 3;
            City = "Kazan";
            BeginDate = DateTime.Today;
            EndDate = DateTime.Today;
        }
    }
}