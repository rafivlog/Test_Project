using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Hrm.Repository;
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

        [HttpPost]
        public IActionResult Save(AttendanceModel data)
        {

            int result;
            result = AttendanceRepository.Create(data);


            return Json(result);


        }

    }
}
