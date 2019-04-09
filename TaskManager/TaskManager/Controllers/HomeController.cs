using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private List<TaskDTO> _Tasks;

        /// <summary>
        /// Constructor, initialize list of Task
        /// </summary>
        public HomeController()
        {
            _Tasks = new List<TaskDTO>()
            {
                new TaskDTO(){ID=1, Name="Pasear a mi perro"},
                new TaskDTO(){ID=2, Name="Tirar la basura"},
                new TaskDTO(){ID=3, Name="Llamar a mami"}
            };
        }
        
        /// <summary>
        /// Get list of tasks
        /// </summary>
        
        public ActionResult Index(int? start, int? length, int? id)
        {
            return RedirectToAction("GetTaskById", new { id = id });

            List<TaskDTO> tasks = _Tasks;

            if (start.HasValue) {
                tasks = tasks.Skip(start.Value).ToList();
            }

            if (length.HasValue) {
                tasks = tasks.Take(length.Value).ToList();
            }


            StringBuilder content = new StringBuilder();

            foreach (TaskDTO task in tasks) {
                content.Append(string.Format("<div>Id: {0}, Name: {1}</div>", task.ID, task.Name));
            }

            return new ContentResult()
            {
                Content = content.ToString()
            };
        }

        /// <summary>
        /// Print a task by task ID
        /// </summary>
        
        public ActionResult GetTaskById(int? id) {

            if (!id.HasValue)
            {
                return new ContentResult()
                {
                    Content = "<div>ID parameter is required!</div>"
                };
            }

            TaskDTO task = _Tasks.Where(t => t.ID == id).FirstOrDefault();

            return new ContentResult()
            {
                Content = task == null ?
                string.Format("<div>Task {0} not found</div>", id) :
                string.Format("<div>Id: {0}, Name: {1}</div>", task.ID, task.Name)
            };
        }
    }
}