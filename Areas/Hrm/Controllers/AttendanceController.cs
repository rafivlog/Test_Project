using Microsoft.AspNetCore.Mvc;

namespace Infiniatask.Areas.Hrm.Controllers
{
    [Area("Hrm")]
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Attendance()
        {
            return View();
        }
    }
}
