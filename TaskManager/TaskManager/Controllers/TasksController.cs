using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.CommandServices;
using TaskManager.Models;
using TaskManager.Tasks;

namespace TaskManager.Controllers
{
    public class TasksController : Controller
    {
        private TaskQueryServices _taskQueryServices;
        private TaskCommandService _taskCommandService;

        /// <summary>
        /// Constructor, initialize list of Task
        /// </summary>
        public TasksController()
        {
            _taskQueryServices = new TaskQueryServices();
            _taskCommandService = new TaskCommandService();
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
            return View("TaskView", new TaskView()
            {
                Task = new TaskDTO()
                {
                    DueDate = DateTime.Now.AddDays(1),
                }
            });
        }

        /// <summary>
        /// Go to new task View
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(TaskDTO task)
        {
            if (ModelState.IsValid)
            {
                _taskCommandService.CreateTask(task);
                return RedirectToAction("Edit", new { id = task.ID, fc = 1 });
            }
            else
            {
                TaskView model = new TaskView()
                {
                    Task = task
                };
                return View("TaskView",model);
            }
        }

        /// <summary>
        /// Go to edit task View
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id, int? fc)
        {
            TaskDTO task = _taskQueryServices.GetTasksByID(id);
            TaskView model = new TaskView()
            {
                Task = task,
                ErrorMessage = task == null ? "Error - Task not found" : "",
                SuccessMessage = fc.HasValue && fc == 1 ? "Task successfully created": ""
            };
            return View("TaskView", model);
        }

        /// <summary>
        /// Update an existing task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(TaskDTO task)
        {
            // return the task to the user
            TaskView model = new TaskView()
            {
                Task = task,
            };

            //save changes
            //HttpContext context = System.Web.HttpContext.Current;
            try
            {
                if (ModelState.IsValid)
                {
                    _taskCommandService.UpdateTask(task);
                    model.SuccessMessage = "Task successfully saved";
                }
            }
            catch (Exception ex)
            {
                model.ErrorMessage = ex.ToString();
            }

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