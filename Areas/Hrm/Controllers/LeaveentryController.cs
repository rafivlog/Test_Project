using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Hrm.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Infiniatask.Areas.Hrm.Controllers
{
    [Area("Hrm")]
    public class LeaveentryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Leave()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(LeaveentryModel data)
        {

            int result;
            result = LeaveentryRepository.Create(data);


            return Json(result);


        }
    }
}
