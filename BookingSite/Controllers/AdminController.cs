using System.Threading.Tasks;
using BookingShared.Interfaces;
using BookingShared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSite.Controllers
{
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        private readonly IRepository _repository;
        private UserManager<AppUser> _userManager { get; set; }
        private SignInManager<AppUser> _signInMgr { get; set; }
        private RoleManager<AppRole> _rolesMgr { get; set; }

        public AdminController(IRepository repository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> rolesManager)  
        {
            _repository = repository;
            _userManager = userManager;
            _signInMgr = signInManager;
            _rolesMgr = rolesManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(user);
            return View(roles);
        }

        public async Task<IActionResult> BecomeAdmin()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            await _userManager.AddToRoleAsync(user, "admin");
            return View();
        }
    }
}