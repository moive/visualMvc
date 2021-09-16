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
    }
}