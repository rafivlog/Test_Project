using Microsoft.AspNetCore.Mvc;

namespace Infiniatask.Areas.Hrm.Controllers
{
    [Area("Hrm")]
    public class EmpdashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {

            return View();
        }
    }
}
