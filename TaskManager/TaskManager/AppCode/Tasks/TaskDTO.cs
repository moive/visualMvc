using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager
{
    public class TaskDTO
    {
        public int ID { get; set; }

        [System.Web.Mvc.Remote("CheckTaskNameExists", "Tasks")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Maximum length is 100")] 
        [MinLength(3, ErrorMessage = "Minimun length is 3")]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Due date is required")]
        public DateTime DueDate { get; set; }
    }
}