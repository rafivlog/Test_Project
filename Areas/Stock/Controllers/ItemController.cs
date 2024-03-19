using Microsoft.AspNetCore.Mvc;

namespace Infiniatask.Areas.Stock.Controllers
{
    [Area("Stock")]
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Additem()
        {
            return View();
        }
    }
}
