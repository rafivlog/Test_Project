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

       /* [HttpGet]*/
        /*public async IActionResult dropdown(AttendanceModel data) 
        {
            List<AttendanceModel> employees = (await AttendanceRepository.GetAllEmployeesAsync()).ToList();
            return View(employees);

        }*/

    }
}
