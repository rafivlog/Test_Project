using Infiniatask.Areas.Hrm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;

namespace Infiniatask.Areas.Hrm.Controllers
{
    [Area("Hrm")]
    public class SSRSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        string msg = "";
        public CultureInfo culture = new CultureInfo("es-ES");


        public IActionResult LoadReport()
        {
            string selectedreport = HttpContext.Request.Cookies["hrmsreport"];
            ReportParam myreport = JsonConvert.DeserializeObject<ReportParam>(selectedreport);
            ServerReport report = new ServerReport();
            report.ReportServerCredentials.NetworkCredentials = new NetworkCredential("Administrator", "6251", "Rahat");
            report.ReportServerUrl = new Uri("http://192.168.0.75:89/ReportServer");
            report.ReportPath = myreport.rptPath;
            if (myreport.rptKey == "searchMonth")
            {
                report.SetParameters(new[]
                {
                      new ReportParameter("month",myreport.rptDate),

                  });
            }




           

            byte[] pdf = report.Render("PDF");








            HttpContext.Response.Cookies.Delete("hrmsreport");
            return File(pdf, "application/pdf");
        }
    }
}


//C:\infiniatask-20240418T034117Z-001\infiniatask\Infiniatask.csproj