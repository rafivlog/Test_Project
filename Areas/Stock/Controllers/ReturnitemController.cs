using Infiniatask.Areas.Stock.Models;
using Infiniatask.Areas.Stock.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Infiniatask.Areas.Stock.Controllers
{
    [Area("Stock")]
    public class ReturnitemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Return() 
        {
            return View();
        }

        public IActionResult Save(ReturnitemModel data)
        {

            int result;
            result = RetrunitemRepository.Create(data);


            return Json(result);


        }

        public class retparameterModel
        {
            public int aidi { get; set; }
            public int cataidi { get; set; }
            public int stockaidi { get; set; }
        }
        public IActionResult Getquantity(retparameterModel data)
        {

            var datta = RetrunitemRepository.GetQuantity(data.aidi , data.cataidi, data.stockaidi);
            return Json(datta);
          
          //return View();
        }
    }
}
