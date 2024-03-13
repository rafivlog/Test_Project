﻿using Infiniatask.Areas.Hrm.Models;
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

        [HttpGet]
        public ActionResult GetData(int id)
        {
            int result;
            result = EmployeeRepository.edit(id);

            return Json(new { success = true, Message = "Edited Successfully!" });
        }

        [HttpPost]
        
        public ActionResult UpdateClient(EmployeeModel data)
        {
            int result;
            result = EmployeeRepository.Update(data);
            return Json(result);
        }


        //Forcefully Get ID Number.
        [HttpGet("Employee/Edit/{desig_id}")]
        public ActionResult Edit(int desig_id)
        {


            
            return View();
        }






    }
}
