using Microsoft.AspNetCore.Mvc;
using OIMInformationTool2.Models;

namespace OIMInformationTool2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private OimContext db = new OimContext();
        public ActionResult Index()
        {
            this.HttpContext.Session.SetString("tipoUsuario", "3");
            return View();
        }

        public ActionResult StartSession()
        {


            return RedirectToAction("Index", "Home");
        }

        public ActionResult LoginP()
        {
            this.HttpContext.Session.SetString("user", "admin");
            this.HttpContext.Session.SetString("tipoUsuario", "3");
            return RedirectToAction("Index", "Home");
        }

    }
}