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
        public ActionResult Index(TaskDTO task)
        {
            return new JsonResult() {
                Data = task,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}