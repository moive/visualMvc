using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Services;

namespace TaskManager.Tasks
{
    public class TaskQueryServices
    {
        //private GlobalDbContext _context;

        public TaskQueryServices()
        {
            //_context = new GlobalDbContext();
        }
        public List<TaskDTO> GetTasks()
        {
            using(GlobalDbContext context = new GlobalDbContext())
            {
                return context.Tasks().ToList();
            }
        }

        public TaskDTO GetTasksByID(int id)
        {
            using (GlobalDbContext context = new GlobalDbContext())
            {
                return context.Tasks().Where(t=> t.ID == id).FirstOrDefault();
            }
        }
    }
}