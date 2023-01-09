using Microsoft.AspNetCore.Mvc;
using OIMInformationTool2.Models;
using System.Diagnostics;

namespace OIMInformationTool2.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

    }
}