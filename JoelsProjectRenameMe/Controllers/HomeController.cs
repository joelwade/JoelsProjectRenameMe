using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoelsProjectRenameMe.Controllers
{

    public class HomeController : Controller
    {

        //CartModel.ModelCart db = new CartModel.ModelCart();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
