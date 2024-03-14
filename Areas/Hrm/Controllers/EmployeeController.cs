using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Hrm.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop.Implementation;

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

        [HttpGet]
/*        ekhane attendace from er dropdown er jnne employee theke data nicci */        
        public IActionResult GetDropdownData()
        {

            IEnumerable<DropDownModel> data = EmployeeRepository.GetDropDownData();
            return Json(data);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            int result;
            result = EmployeeRepository.delete(id);
            //return Json(result);
           
            return Json(new { success = true, Message = "Delete Successfully!" });
        }

      


        //Forcefully Get ID Number. // Edit eta hcce View page tay viewbag use kory nai same page er mddhey data Model er maddhome pathacci 
        [HttpGet("Employee/Edit/{desig_id}")]
        public ActionResult Edit(int desig_id)
        {
            //data show on edit page .placeholder
            EmployeeModel data = EmployeeRepository.geteditdata(desig_id);


            
            return View(data);
        }

        //data edit kore save kortci abr

        [HttpPost]
        public ActionResult update(EmployeeModel data)
        {
            int result;
            result = EmployeeRepository.Update(data);


            return Json(result);

        }






    }
}
