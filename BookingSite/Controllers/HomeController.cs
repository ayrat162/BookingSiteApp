using BookingBLL;
using BookingBLL.Helpers;
using BookingShared.Interfaces;
using BookingShared.Models;
using BookingSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BookingSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repository, IEmailService emailService)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var hotelsCount = _repository.List<HotelModel>().Count;
            var showPopulateButton = (hotelsCount == 0);
            return View(showPopulateButton);
        }

        public async Task<IActionResult> Populate()
        {
            PopulateHelper.PopulateHotels(_repository);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
