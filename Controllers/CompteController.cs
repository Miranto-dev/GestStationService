using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestStationService.Controllers
{
    public class CompteController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;    //UserManager assure la gestion des comptes
        private readonly SignInManager<IdentityUser> _signInManager;    //SignInManager assure la gestion des pages de connexions (Login , logout)
        
        public CompteController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
