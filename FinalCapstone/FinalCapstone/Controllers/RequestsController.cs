using FinalCapstone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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
            return View();
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            Request request = new Request();
            return View(request);
        }

        // POST: Requests/Create
        [HttpPost]
        public ActionResult Create(Request request, int id)
        {
            try
            {
                request.TeammemberId = id;
                var foundRelationship = db.TeammemberTeam.Where(a=>a.TeammemberId == request.TeammemberId).FirstOrDefault();
                //var foundRequest.TeamId = foundRelationship.TeamId;
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
            return View();
        }

        // POST: Requests/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

        // POST: Requests/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
