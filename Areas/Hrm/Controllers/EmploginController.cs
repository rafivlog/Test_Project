using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Hrm.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infiniatask.Areas.Hrm.Controllers
{
    [Area("Hrm")]
    public class emploginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult loginmatch(EmploginModel data)
        {

            int result;
            result = EmploginRepository.match(data);

            if (result == 0)
            {
                return Json(false);
            }
            else
            {
                return Json(result);
            }
            
        }
    }
}
