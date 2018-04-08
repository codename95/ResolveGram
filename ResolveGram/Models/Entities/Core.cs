using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResolveGram.Models.Entities
{
    public class Account
    {
        [Key]
        public long AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> LastSeen { get; set; }
        public Nullable<short> Rating { get; set; }
        public Nullable<System.Guid> Code { get; set; }
        public string YouTubeCode { get; set; }
        
        public virtual ICollection<TaskList> Tasks { get; set; }
    }

    public  class Category
    {
        public Category()
        {
            this.Tasks = new HashSet<TaskList>();
        }
        [Key]
        public byte CategoryID { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<TaskList> Tasks { get; set; }
    }

    public  class Organisation
    {
        [Key]
        public int OrganisationID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> StaffNo { get; set; }
    }
    public  class Priority
    {
        public Priority()
        {
            this.Tasks = new HashSet<TaskList>();
        }
        [Key]
        public byte PriorityID { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<TaskList> Tasks { get; set; }
    }

    public  class SubTask
    {
        [Key]
        public long SubTaskID { get; set; }
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public System.DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string AssignedTo { get; set; }
        public System.Guid Code { get; set; }

        public virtual TaskList Task { get; set; }
    }

    public  class TaskList
    {
        public TaskList()
        {
            this.SubTasks = new HashSet<SubTask>();
        }
        [Key]
        public long TaskID { get; set; }
        public string TaskTitle { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime DueDate { get; set; }
        public bool SendEmail { get; set; }
        public bool SendTextMessage { get; set; }
        public bool ShowHomePage { get; set; }
        public string Notes { get; set; }
        public byte CategoryID { get; set; }
        public System.DateTime DateCreated { get; set; }
        //public byte[] TimeStamp { get; set; }
        public long AccountID { get; set; }
        public bool IsComplete { get; set; }
        public Nullable<byte> PriorityID { get; set; }
        public string AssignTo { get; set; }
        public System.Guid Code { get; set; }

        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
        public virtual Priority Priority { get; set; }

        public virtual ICollection<SubTask> SubTasks { get; set; }
    }

    public  class Notification
    {
       
        [Key]
        public long NotificationID { get; set; }
        public string Message { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool IsRead { get; set; }
        public long AccountID { get; set; }
        public string Icon { get; set; }
        public string CssClass { get; set; }

        public virtual Account Account { get; set; }
       
    }
}