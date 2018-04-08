using PagedList;
using ResolveGram.Business;
using ResolveGram.Models.ChronJob;
using ResolveGram.Models.Entities;
using ResolveGram.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ResolveGram.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ResolveGramTransactions obj = new ResolveGramTransactions();
        public ActionResult Dashboard()
        {
            var dashboard = obj.GetDashBoardInfo();
            return View(dashboard);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
           
            return  View();
        }
        public async void Do()
        {
            JobScheduler.Start();
        }

        public ActionResult AddTask(string id)
        {
            var m = new TaskViewModel
            {
                Priorities = obj.GetPriorities(),
                Categories = obj.GetCategories()
            };
            ViewBag.Msg = id;
            return View(m);
        }

        [HttpPost]
        public ActionResult AddTask(TaskViewModel model)
        {

            var response = obj.AddTask(model);
            if (response)
            {
                return RedirectToAction("AddTask", new { id = 1 });
            }
            return View();
        }

        public ActionResult AllTask(string sortOrder, string currentFilter, string key, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
            ViewBag.PrioritySortParm = sortOrder == "Priority" ? "priority_desc" : "Priority";
            ViewBag.IsCompleteSortParm = sortOrder == "Completion" ? "completion_desc" : "Completion";
            ViewBag.DueDateParm = sortOrder == "DueDate" ? "due_desc" : "DueDate";

            if (key != null)
            {
                page = 1;
            }
            else
            {
                key = currentFilter;
            }

            ViewBag.CurrentFilter = key;

            var tasks = from s in obj.GetAllTasks()
                        select s;
            if (!String.IsNullOrEmpty(key))
            {
                tasks = tasks.Where(s => s.TaskTitle.ToUpper().Contains(key.ToUpper())
                                       || s.Notes.ToUpper().Contains(key.ToUpper()));
            }
            #region sortOrders
            switch (sortOrder)
            {
                case "name_desc":
                    tasks = tasks.OrderByDescending(s => s.TaskTitle);
                    break;
                case "Date":
                    tasks = tasks.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    tasks = tasks.OrderByDescending(s => s.DateCreated);
                    break;
                case "Category":
                    tasks = tasks.OrderBy(s => s.CategoryID);
                    break;
                case "category_desc":
                    tasks = tasks.OrderByDescending(s => s.CategoryID);
                    break;
                case "Priority":
                    tasks = tasks.OrderBy(s => s.PriorityID);
                    break;
                case "priority_desc":
                    tasks = tasks.OrderByDescending(s => s.PriorityID);
                    break;
                case "Completion":
                    tasks = tasks.OrderBy(s => s.IsComplete);
                    break;
                case "completion_desc":
                    tasks = tasks.OrderByDescending(s => s.IsComplete);
                    break;
                case "DueDate":
                    tasks = tasks.OrderBy(s => s.IsComplete);
                    break;
                case "due_desc":
                    tasks = tasks.OrderByDescending(s => s.IsComplete);
                    break;
                default:  // Name ascending 
                    tasks = tasks.OrderBy(s => s.DueDate);
                    break;
            }
            #endregion
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tasks.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult TaskDetail(long taskID)
        {
            var task = obj.ViewTask(taskID);
            return PartialView("TaskDetailPartial", task);
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult Account()
        {
            var user = obj.GetUser();
            return View(user);
        }


        public ActionResult DeleteTask(long id)
        {
            try
            {
                var response = obj.DeleteTask(id);
                if (response) ;
                return RedirectToAction("AllTask", "Home");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Report()
        {
            return View();
        }
        //
        [HttpPost]
        public ActionResult GetResultByAjax(int? id)
        {
            List<Employee> empList = new List<Employee>()
     {
         new Employee{EmpID = 5, FirstName = "Mahesh", LastName = "Chand"},
         new Employee{EmpID = 6, FirstName = "Parveen", LastName = "Kumar"},
         new Employee{EmpID = 7, FirstName = "Dinesh", LastName = "Beniwal"},
         new Employee{EmpID = 4, FirstName = "Dhananjay", LastName = "Kumar"}
     };

            return PartialView("DemoPartial", empList.Where(f => f.EmpID == id).ToList());
        }

        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int EmpID { get; set; }

        }
        //
    }
}