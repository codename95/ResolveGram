
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ResolveGram.Models;
using ResolveGram.Models.Entities;
using ResolveGram.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResolveGram.Business
{
    public class ResolveGramTransactions
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Account GetUser()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(HttpContext.Current.User.Identity.GetUserId());
            var user = currentUser.Account;
            return user;
        }

        //Subtask
        #region Subtask
        public IEnumerable<SubTask> GetAllSubTasks(int taskId)
        {

            var subtasks = (from c in db.SubTask where c.TaskID == taskId select c).OrderByDescending(f => f.DueDate).ToList();
            return subtasks;
        }

        public bool AddSubTask(SubTask model)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public bool UpdateSubTask(int id, SubTask model)
        {
            return true;
        }

        public bool DeleteSubTask(int id)
        {
            return true;
        }

        public bool ViewSubTask(int id)
        {
            return true;
        }
        #endregion


        //Tasks
        public IEnumerable<TaskList> GetAllTasks()
        {
            var account = GetUser().AccountID;
            var tasks = db.TaskList.Where(f => f.AccountID == account).OrderByDescending(d => d.DateCreated).ToList();
            return tasks;
        }

        public bool AddTask(TaskViewModel model)
        {

            try
            {
                var newTask = new TaskList
                {
                    TaskTitle = model.TaskTitle,
                    StartDate = model.StartDate,
                    DueDate = model.DueDate,
                    SendEmail = model.SendEmail,
                    SendTextMessage = model.SendTextMessage,
                    ShowHomePage = false,
                    Notes = model.Notes,
                    CategoryID = model.CategoryID,
                    DateCreated = DateTime.Now,
                    AccountID = GetUser().AccountID,
                    IsComplete = false,
                    PriorityID = model.PriorityID,
                    Code = Guid.NewGuid()
                };
                db.TaskList.Add(newTask);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTask(int id, TaskList model)
        {
            return true;
        }

        public bool DeleteTask(long id)
        {
            try
            {
                var task = db.TaskList.Find(id);
                db.TaskList.Remove(task);
                db.SaveChanges();
                return true;
            }
            catch ( Exception err)
            {

                return false;
            }
           
        }

        public TaskList ViewTask(long id)
        {
            var account = GetUser().AccountID;
            var task = (from c in db.TaskList where c.TaskID == id && c.AccountID == account select c).First();
            /* USE VIEW MODEL TO PREVENT HACK */
            //var model = new TaskViewModel
            //{
            //    TaskID = task.TaskID,
            //    TaskTitle = task.TaskTitle,
            //    Notes = task.Notes,
            //    StartDate = task.StartDate,
            //    DueDate = task.DueDate,
            //    IsComplete = task.IsComplete,
            //    PriorityID = task.PriorityID.Value,
            //    CategoryID = task.CategoryID,
            //    AssignTo = task.AssignTo,
            //};
            return task;
        }

        public HomeDashBoardViewModel GetDashBoardInfo()
        {
            var accountId = GetUser().AccountID;
            var myTasks = db.TaskList.Where(f => f.AccountID == accountId).ToList();
            
            var model = new HomeDashBoardViewModel
            {
                TodayTask = myTasks.Where(d => d.StartDate.Day == DateTime.Now.Day && d.StartDate.Month == DateTime.Now.Month && d.StartDate.Year == DateTime.Now.Year).Count(),
                TommorrowsTask = myTasks.Where(d => d.StartDate.Day == DateTime.Now.AddDays(1).Day && d.StartDate.Month == DateTime.Now.AddDays(1).Month && d.StartDate.Year == DateTime.Now.AddDays(1).Year).Count(),
                NestWeekTask = myTasks.Where(d => d.StartDate.Day == DateTime.Now.AddDays(7).Day && d.StartDate.Month == DateTime.Now.AddDays(7).Month && d.StartDate.Year == DateTime.Now.AddDays(7).Year).Count(),
                CompletedTask = myTasks.Where(f => f.IsComplete).Count(),
                VideoCode = GetUser().YouTubeCode,
                Notifications = db.Notification.Where(o => o.AccountID== accountId).ToList()
            };
            return model;
        }


        //Other Operations
        public List<Priority> GetPriorities()
        {
            return db.Priority.ToList();
        }

        public List<Category> GetCategories()
        {
            return db.Category.ToList();
        }
    }
}