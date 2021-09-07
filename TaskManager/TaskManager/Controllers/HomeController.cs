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
        private TaskQueryServices _taskQueryServices;

        /// <summary>
        /// Constructor, initialize list of Task
        /// </summary>
        public HomeController()
        {
            _taskQueryServices = new TaskQueryServices();
        }

        /// <summary>
        /// Get list of tasks
        /// </summary>
        public ActionResult Index()
        {
            TaskList model = new TaskList()
            {
                ListOfTasks = _taskQueryServices.GetTasks()

            };

            return View(model);
        }

        /// <summary>
        /// Get Task without layout
        /// </summary>
        /// <returns></returns>
        public ActionResult Task()
        {
            ViewBag.Description = "View without layout";
            return View();
        }
    }
}