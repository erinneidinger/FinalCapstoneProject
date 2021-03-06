﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FinalCapstone.Models;
using Microsoft.AspNet.Identity;

namespace FinalCapstone.Controllers
{
    public class OrganizationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Organizations
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var teammember = db.Teammembers.Where(a => a.ApplicationId == userId).FirstOrDefault();
            ViewBag.TeammemberId = teammember.TeammemberId;
            return View(db.Organizations.ToList());
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            ViewBag.ApiCall = organization.APICall;
            var userId = User.Identity.GetUserId();
            ViewBag.ApplicationId = userId;
            var teammember = db.Teammembers.Where(a => a.ApplicationId == userId).FirstOrDefault();
            ViewBag.TeammemberId = teammember.TeammemberId;
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            Organization organization = new Organization();
            return View(organization);
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                organization.ApplicationId = userId;
                db.Organizations.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(organization);
            }
        }

        //public ActionResult IndividualTeams()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var foundMember = db.Teammembers.Where(a => a.ApplicationId == userId).FirstOrDefault();
        //    var member = db.TeammemberTeam.Where(a => a.TeammemberId == foundMember.TeammemberId).FirstOrDefault();
        //    if (member == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    var foundTeams = db.TeammemberTeam.Where(a=>a.TeamId == member.TeamId).ToList();
        //    foreach(TeammemberTeam team in foundTeams)
        //    {
        //        var newTeamNames = db.Teams.Where(a => a.TeamId == team.TeamId).ToList();
        //        foreach(Team theTeam in newTeamNames)
        //        {
        //            var theTeams = db.Teams.Where(a => a.Name == theTeam.Name).ToList();
        //            return View(theTeams);
        //        }
        //    }
        //    //var foundOrganization = db.Organizations.Find(foundTeams.OrganizationId);
        //    //ViewBag.OrganizationName = foundOrganization.Name;
        //    return View("Index");
        //}

        // GET: Organizations/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
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
