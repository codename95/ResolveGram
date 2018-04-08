using ResolveGram.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResolveGram.Models.ViewModel
{
    public class TaskViewModel
    {
        public long? TaskID { get; set; }
        public string TaskTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool SendEmail { get; set; }
        public bool SendTextMessage { get; set; }
        public bool? ShowHomePage { get; set; }
        public string Notes { get; set; }
        public byte CategoryID { get; set; }
        public long AccountID { get; set; }
        public bool? IsComplete { get; set; }

        public byte PriorityID { get; set; }
        public string AssignTo { get; set; }

        public IEnumerable<Priority> Priorities { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public virtual Priority Priority { get; set; }
        public virtual Category Category { get; set; }
    }
}