using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return new ContentResult() {
                Content = "<h1 class='heading-h1'>Hello TaskManager</h1>"
            };
        }
    }
}