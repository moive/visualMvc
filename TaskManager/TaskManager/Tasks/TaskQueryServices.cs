using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Services;

namespace TaskManager.Tasks
{
    public class TaskQueryServices
    {
        private GlobalDbContext _context;

        public TaskQueryServices()
        {
            _context = new GlobalDbContext();
        }
        public List<TaskDTO> GetTasks()
        {
            return _context.Tasks().ToList();
        }
    }
}