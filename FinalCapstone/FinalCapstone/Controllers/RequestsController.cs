using FinalCapstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinalCapstone.Controllers
{
    public class RequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Requests
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }

        // GET: Requests/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            Request request = new Request();
            return View(request);
        }

        // POST: Requests/Create
        [HttpPost]
        public ActionResult Create(Request request)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var teammemberName = db.Teammembers.Where(a => a.ApplicationId == userId).FirstOrDefault();
                var teamName = db.Teammembers.Where(a => a.TeammemberId == teammemberName.TeammemberId).FirstOrDefault();
                request.FirstName = teamName.FirstName;
                request.LastName = teamName.LastName;
                request.TeammemberId = teamName.TeammemberId;
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(request);
            }
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Request request, int id)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var teammemberName = db.Teammembers.Where(a => a.ApplicationId == userId).FirstOrDefault();
                var teamName = db.Teammembers.Where(a => a.TeammemberId == teammemberName.TeammemberId).FirstOrDefault();
                request.TeammemberId = teamName.TeammemberId;
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
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
