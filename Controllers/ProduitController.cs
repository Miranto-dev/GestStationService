using Microsoft.AspNetCore.Mvc;

namespace GestStationService.Controllers
{
    public class ProduitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
