using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Tasks;

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {
        private TaskQueryServices _taskQueryServices;

        /// <summary>
        /// Constructor, initialize list of Task
        /// </summary>
        public TasksController()
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

        /// <summary>
        /// Go to new task View
        /// </summary>
        /// <returns></returns>
        public ActionResult New()
        {
            return View("TaskView", new TaskView());
        }

        /// <summary>
        /// Go to edit task View
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            TaskDTO task = _taskQueryServices.GetTasksByID(id);
            TaskView model = new TaskView()
            {
                Task = task,
                ErrorMessage = task == null ? "Error - Task not found" : ""
            };
            return View("TaskView", model);
        }

        /// <summary>
        /// Go to delete task View
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            //TaskView model = new TaskView()
            //{
            //    Task = _taskQueryServices.GetTasksByID(id)
            //};
            //return View("TaskView", model);
            throw new NotImplementedException();
        }
    }
}