﻿using System;
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
        public ActionResult Index()
        {
            ViewBag.ListOfTasks = _Tasks;
            return View();
        }
    }
}