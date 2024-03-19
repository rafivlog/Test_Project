using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Hrm.Repository;
using Infiniatask.Areas.Stock.Models;
using Infiniatask.Areas.Stock.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Infiniatask.Areas.Stock.Controllers
{
    [Area("Stock")]
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<CategoryModel> categorylist = CategoryRepository.getcategory();


            ViewBag.category = categorylist;

            return View();
        }

        [HttpPost]
        public IActionResult Save(CategoryModel data)
        {

            int result;
            result = CategoryRepository.Create(data);
            return Json(result);


        }

        public IActionResult GetDropdownData()
        {

            IEnumerable<dropdownModel> data = CategoryRepository.GetDropDownData();
            return Json(data);
        }


        /*public IActionResult Show()
        {
            List<CategoryModel> categorylist = CategoryRepository.getcategory();


            ViewBag.category = categorylist;
            return View();
        }
        */

    }
}
