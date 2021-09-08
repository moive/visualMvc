using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Tasks;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Get index
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Description = "List of Tasks";
            return View();
        }
    }
}