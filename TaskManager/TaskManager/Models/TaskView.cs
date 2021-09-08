using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class TaskView
    {
        public string ErrorMessage { get; set; }
        public TaskDTO Task { get; set; }
    }
}