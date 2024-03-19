using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Hrm.Repository;
using Infiniatask.Areas.Stock.Models;
using Infiniatask.Areas.Stock.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Infiniatask.Areas.Stock.Controllers
{
    [Area("Stock")]
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Additem()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Save(ItemModel data)
        {

            int result;
            result = ItemRepository.Create(data);


            return Json(result);


        }


        public IActionResult Itemlist()
        {
            List<ItemModel> itemlist = ItemRepository.getitemlist();


            ViewBag.item = itemlist;
            return View();
        }
    }
}
