using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TaskManager.Services
{
    public class TaskModel : EntityTypeConfiguration<TaskDTO>
    {
        public TaskModel()
        {
            this.HasKey(t => t.ID);

            this.Property(t => t.Name).HasMaxLength(100).IsRequired();
            this.Property(t => t.CreateDate).IsRequired();
            this.Property(t => t.DueDate).IsRequired();
            this.ToTable("tasks");
        }
    }
}