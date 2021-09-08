using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Tasks;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private TaskQueryServices _taskQueryServices;

        /// <summary>
        /// Constructor, initialize list of Task
        /// </summary>
        public TaskController()
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

            return View("TaskList", model);
        }
    }
}