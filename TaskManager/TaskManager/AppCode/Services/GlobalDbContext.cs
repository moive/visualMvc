﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskManager.Services
{
    public class GlobalDbContext : DbContext
    {
        public GlobalDbContext() : base("mgcDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaskModel());
        }

        public IQueryable<TaskDTO> Tasks(bool trackChanges = false)
        {
            IQueryable<TaskDTO> query = this.Set<TaskDTO>();
            if (!trackChanges)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public void Add<T>(T theElement) where T: class
        {
            this.Set<T>().Add(theElement);
        }

        public virtual void Remove(TaskDTO task) 
        {
            this.Entry(task).State = EntityState.Deleted;
        }
    }
}