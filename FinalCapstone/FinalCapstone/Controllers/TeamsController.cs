using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using FinalCapstone.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace FinalCapstone.Controllers
{
    public class TeamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teams
        public ActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            Team team = new Team();
            return View(team);
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var newOrganization = db.Organizations.Where(a => a.ApplicationId == userId).FirstOrDefault();
                var foundOrganization = db.Organizations.Where(a => a.OrganizationId == newOrganization.OrganizationId).FirstOrDefault();
                team.OrganizationId = foundOrganization.OrganizationId;
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("AddToJunction");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AddToJunction(TeammemberTeam teammemberteam)
        {
            var userId = User.Identity.GetUserId();
            var newTeammember = db.Teammembers.Where(a => a.ApplicationId == userId).FirstOrDefault();
            var foundOrganzation = db.Organizations.Where(a => a.ApplicationId == newTeammember.ApplicationId).FirstOrDefault();
            var foundTeam = db.Teams.Where(a => a.OrganizationId == foundOrganzation.OrganizationId).FirstOrDefault();
            teammemberteam.TeamId = foundTeam.TeamId;
            teammemberteam.TeammemberId = newTeammember.TeammemberId;
            db.TeammemberTeam.Add(teammemberteam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamId")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
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
