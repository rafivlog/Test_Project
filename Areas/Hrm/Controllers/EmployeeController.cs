using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Hrm.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infiniatask.Areas.Controllers
{
    [Area("Hrm")]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        //form er data save krtci ekhane DB te
        public IActionResult Save(EmployeeModel data)
        {

            int result ;
            result = EmployeeRepository.Create(data);


            return Json(result); 


        }

        // first bar e load hoye jaowar jnne korci eta ... Button diye anar lagle add er moto kora lagbe .
        public IActionResult Show()
        {
            List<EmployeeModel> emplist = EmployeeRepository.getemployee();
            

            ViewBag.employee = emplist;
            return View();
        }


      
    }
}
