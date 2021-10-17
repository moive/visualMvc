using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Services;

namespace TaskManager.CommandServices
{
    public class TaskCommandService
    {
        public void UpdateTask(TaskDTO task)
        {
            using (GlobalDbContext context = new GlobalDbContext())
            {
                //load task froom database
                TaskDTO existingTask = context.Tasks(true).Where(t => t.ID == task.ID).FirstOrDefault();

                //assing values
                existingTask.DueDate = task.DueDate;
                existingTask.Name = task.Name;

                //save changes to db
                context.SaveChanges();
            }
        }

        public void CreateTask(TaskDTO task)
        {
            using (GlobalDbContext context = new GlobalDbContext())
            {
                //assing create date
                task.CreateDate = DateTime.Now;

                //add task to context
                context.Add(task);

                //save changes to db
                context.SaveChanges();
            }
        }

        public bool taskNotExists(string name)
        {
            using (GlobalDbContext context = new GlobalDbContext())
            {
                return context.Tasks(true).Where(t => t.Name == name).Count() == 0;
            }
        }
    }
}