using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeSheet2017.Models;

namespace TimeSheet2017.Controllers
{
    [Authorize]
    public class TimeLogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Reporting

        public ActionResult Reporting()
        {
            var timeLogs = db.TimeLogs.Include(t => t.Clients);
            return View(timeLogs.ToList());
        }


        //Associate View

        public ActionResult AssociateView()
        {
            var timeLogs = db.TimeLogs.Include(t => t.Clients);

            ////////////////////////////////////
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            ViewBag.AssociateName = currentUser.AssociateName;
            //////////////////////////////////
            return View(timeLogs.ToList());
        }

        // GET: TimeLogs
       // [Authorize(Users = "Manager@Timesheet2017.com")] // only manager super user can see everything
        public ActionResult Index()
        {
            var timeLogs = db.TimeLogs.Include(t => t.Clients);

            //////////////////////////////////////////////////////////
            ///Redirect to control security - Only super user is allowed to see the master time log screen
            if (User.Identity.Name == "Manager@Timesheet2017.com")
            {
                 return View(timeLogs.ToList());
            }
            else
            {
                return RedirectToAction("AssociateView");
            }
            ////////////////////////////////////////////////////////



           
        }

        // GET: TimeLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeLog timeLog = db.TimeLogs.Find(id);
            if (timeLog == null)
            {
                return HttpNotFound();
            }
            return View(timeLog);
        }
        
        // GET: TimeLogs/Create
        [Authorize]
        public ActionResult Create()
        {
             ///////////////////////////////////////////////
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "CompanyName");
            
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            ViewBag.AssociateName = currentUser.AssociateName;

           //////////////////////////////////////////////
      
                return View();
        }

        // POST: TimeLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LogID,TimeStamp,AssociateName,ClientID,WorkDate,NumberHours,WorkType,JobNote")] TimeLog timeLog)
        {
            if (ModelState.IsValid)
            {

                db.TimeLogs.Add(timeLog);
                db.SaveChanges();
                //////////////////////////////////////////////////////////
                ///Redirect to control security - Only super user is allowed to see the master time log screen
                if (User.Identity.Name == "Manager@Timesheet2017.com")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("AssociateView");
                }
                ////////////////////////////////////////////////////////
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "CompanyName", timeLog.ClientID);
            return View(timeLog);
        }

        // GET: TimeLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeLog timeLog = db.TimeLogs.Find(id);
            if (timeLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "CompanyName", timeLog.ClientID);
            return View(timeLog);
        }

        // POST: TimeLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LogID,TimeStamp,AssociateName,ClientID,WorkDate,NumberHours,WorkType,JobNote")] TimeLog timeLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeLog).State = EntityState.Modified;
                db.SaveChanges();
                //////////////////////////////////////////////////////////
                ///Redirect to control security - Only super user is allowed to see the master time log screen
                if (User.Identity.Name == "Manager@Timesheet2017.com")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("AssociateView");
                }
                ////////////////////////////////////////////////////////
                //return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "CompanyName", timeLog.ClientID);
            return View(timeLog);
        }

        // GET: TimeLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeLog timeLog = db.TimeLogs.Find(id);
            if (timeLog == null)
            {
                return HttpNotFound();
            }
            return View(timeLog);
        }

        // POST: TimeLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeLog timeLog = db.TimeLogs.Find(id);
            db.TimeLogs.Remove(timeLog);
            db.SaveChanges();

            //////////////////////////////////////////////////////////
            ///Redirect to control security - Only super user is allowed to see the master time log screen
            if (User.Identity.Name == "Manager@Timesheet2017.com")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AssociateView");
            }
            ////////////////////////////////////////////////////////



            // return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
