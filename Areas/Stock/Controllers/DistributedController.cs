using Infiniatask.Areas.Hrm.Models;
using Infiniatask.Areas.Hrm.Repository;
using Infiniatask.Areas.Stock.Models;
using Infiniatask.Areas.Stock.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Infiniatask.Areas.Stock.Controllers
{
    [Area("Stock")]
    public class DistributedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Distitem() 
        {
            return View();
        }

        public IActionResult GetItemDropdownData(int id)
        {

            IEnumerable<itemdropdownModel> data = DistributedRepository.GetDropDownData(id);
            return Json(data);
        }

        public IActionResult Save(DistributedModel data)
        {

            int result;
            result = DistributedRepository.Create(data);


            return Json(result);


        }

        public IActionResult Show()
        {
            List<DistributedModel> distlist = DistributedRepository.getdistributed();


            ViewBag.dist = distlist;
            return View();
        }

        // extra kaam krtci hbe kina jnina 
        /*public IActionResult qtychanges(int stockid)
        {
            List<DistributedModel> changesqty = DistributedRepository.saveqtychanges(stockid);
            return Json(changesqty);

        }*/
    }
}
