using System.Collections.Generic;

namespace TaskManager.Tasks
{
    internal class GlobalDbContext
    {
        public List<TaskDTO> Tasks { get; internal set; }
    }
}