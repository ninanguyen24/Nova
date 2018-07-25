﻿using System.Web.Mvc;
using _5051.Models;
using _5051.Backend;

namespace _5051.Controllers
{
    public class StudentController : Controller
    {
        // A ViewModel used for the Student that contains the StudentList
        private StudentViewModel StudentViewModel = new StudentViewModel();

        // The Backend Data source
        private StudentBackend StudentBackend = StudentBackend.Instance;

        // GET: Student
        /// <summary>
        /// Index, the page that shows all the Students
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // Load the list of data into the StudentList
            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            return View(StudentViewModel);
        }

        /// <summary>
        ///Market Page
        /// </summary>
        /// <returns></returns>
        // GET: Portal
        public ActionResult Market()
        {
            return View();
        }


        /// <summary>
        /// This display the store after something is bought from the market
        /// </summary>
        /// <returns></returns>
        public ActionResult MarketAfter()
        {
            return View();
        }

        /// <summary>
        /// Student's Avatar page
        /// </summary>
        /// <returns></returns>
        // GET: Portal
        public ActionResult Avatar()
        {
            return View();
        }

        /// <summary>
        /// My Attendance Reports for student
        /// </summary>
        /// <returns></returns>
        // GET: Portal
        public ActionResult Report()
        {
            return View();
        }


        /// <summary>
        /// Read information on a single Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Student/Details/5
        public ActionResult Read(string id = null)
        {
            var myDataStudent = StudentBackend.Read(id);
            if (myDataStudent == null)
            {
                RedirectToAction("Error", "Home", "Invalid Record");
            }

            var myData = new StudentDisplayViewModel(myDataStudent);
            if (myData == null)
            {
                RedirectToAction("Error", "Home", "Invalid Record");
            }

            return View(myData);
        }

        /// <summary>
        /// This opens up the make a new Student screen
        /// </summary>
        /// <returns></returns>
        // GET: Student/Create
        public ActionResult Create()
        {
            var myData = new StudentModel();
            return View(myData);
        }

        /// <summary>
        /// Make a new Student sent in by the create Student screen
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: Student/Create
        [HttpPost]
        public ActionResult Create([Bind(Include=
                                        "Id,"+
                                        "Name,"+
                                        "Description,"+
                                        "Uri,"+
                                        "AvatarId,"+
                                        "Status,"+
                                        "")] StudentModel data)
        {
            if (!ModelState.IsValid)
            {
                // Send back for edit
                return View(data);
            }

            if (data == null)
            {
                // Send to Error Page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                // Return back for Edit
                return View(data);
            }

            StudentBackend.Create(data);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// This will show the details of the Student to update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Student/Edit/5
        public ActionResult Update(string id = null)
        {
            var myDataStudent = StudentBackend.Read(id);
            if (myDataStudent == null)
            {
                RedirectToAction("Error", "Home", "Invalid Record");
            }

            var myData = new StudentDisplayViewModel(myDataStudent);
            if (myData == null)
            {
                RedirectToAction("Error", "Home", "Invalid Record");
            }
            return View(myData);
        }

        /// <summary>
        /// This updates the Student based on the information posted from the udpate page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Student/Update/5
        [HttpPost]
        public ActionResult Update([Bind(Include=
                                        "Id,"+
                                        "Name,"+
                                        "Description,"+
                                        "Uri,"+
                                        "AvatarId,"+
                                        "AvatarLevel,"+
                                        "Tokens,"+
                                        "Status,"+
                                        "")] StudentDisplayViewModel data)
        {
            if (!ModelState.IsValid)
            {
                // Send back for edit
                return View(data);
            }

            if (data == null)
            {
                // Send to Error Page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                // Send back for edit
                return View(data);
            }

            var myDataStudent = new StudentModel(data);
            StudentBackend.Update(myDataStudent);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// This shows the Student info to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Student/Delete/5
        public ActionResult Delete(string id = null)
        {
            var myDataStudent = StudentBackend.Read(id);
            if (myDataStudent == null)
            {
                RedirectToAction("Error", "Home", "Invalid Record");
            }

            var myData = new StudentDisplayViewModel(myDataStudent);
            if (myData == null)
            {
                RedirectToAction("Error", "Home", "Invalid Record");
            }

            return View(myData);
        }

        /// <summary>
        /// This deletes the Student sent up as a post from the Student delete page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include=
                                        "Id,"+
                                        "Name,"+
                                        "Description,"+
                                        "AvatarId,"+
                                        "Uri,"+
                                        "")] StudentDisplayViewModel data)
        {
            if (!ModelState.IsValid)
            {
                // Send back for edit
                return View(data);
            }
            if (data == null)
            {
                // Send to Error page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                // Send back for Edit
                return View(data);
            }

            StudentBackend.Delete(data.Id);

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Display default game store page
        /// </summary>
        /// <returns></returns>
        public ActionResult Default()
        {
            return View();
        }

        /// <summary>
        /// Display community page
        /// </summary>
        /// <returns></returns>
        public ActionResult Community()
        {
            return View();
        }
    }
}
