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
            Team team = new Team();
            ViewBag.TeamId = team.TeamId;
            return View(db.Teams.ToList());
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
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
        public ActionResult Create(Team team, int id)
        {
            try
            { 
                var foundOrganization = db.Organizations.Where(a => a.OrganizationId == id).FirstOrDefault();
                team.OrganizationId = foundOrganization.OrganizationId;
                db.Teams.Add(team);
                db.SaveChanges();
                return View("TeamsList");
                //return RedirectToAction("AddToJunction");
            }
            catch
            {
                return View();
            }
        }

        //Needed?
        //public ActionResult JoinTeam(string id)
        //{
        //    var foundTeammember = db.Teammembers.Where(a => a.ApplicationId == id).FirstOrDefault();

        //}



        //trying to fix this hot mess..
        //public ActionResult PreTeamsList(int id)
        //{
        //    var userId = User.Identity.GetUserId();
        //    var teamMember = db.Teammembers.Where(t => t.ApplicationId == userId).FirstOrDefault();
        //    var foundOrganization = db.Organizations.Where(a => a.OrganizationId == id).FirstOrDefault();
        //    var foundTeams = db.Teams.Where(a => a.OrganizationId == foundOrganization.OrganizationId).ToList();
        //    ViewBag.foundTeams = foundTeams;
        //    ViewBag.OrganizationName = foundOrganization.Name;
        //    ViewBag.OrganizationId = foundOrganization.OrganizationId;
        //    var found = db.TeammemberTeam.Where(a => a.TeammemberId == teamMember.TeammemberId).FirstOrDefault();
        //    ViewBag.Junction = found;
        //    if (found == null)
        //    {
        //        return View(foundTeams);
        //    }
        //    ViewBag.TeamMemberId = teamMember.TeammemberId;
        //    return View("TeamsList");
        //}

        public ActionResult AddToJunction(int Id)
        {
            TeammemberTeam teammemberteam = new TeammemberTeam();
            var userId = User.Identity.GetUserId();
            var newTeammember = db.Teammembers.Where(a => a.ApplicationId == userId).FirstOrDefault();
            var teammemberId = newTeammember.TeammemberId;
            teammemberteam.TeamId = Id;
            var team = db.Teams.Where(a => a.TeamId == teammemberteam.TeamId).FirstOrDefault();
            ViewBag.Team = team.Name;
            teammemberteam.TeammemberId = teammemberId;
            var sameTeammemberteam = db.TeammemberTeam.Where(a => a.TeamId == teammemberteam.TeamId).Where(a=>a.TeammemberId == teammemberteam.TeammemberId).FirstOrDefault();
            if (sameTeammemberteam == null)
            {
                db.TeammemberTeam.Add(teammemberteam);
                db.SaveChanges();
            }
            //ViewBag.sameTeammemberteam = sameTeammemberteam;
            return View(teammemberteam);
        }

        //Duplicate on OrganizationsController?
        public ActionResult TeamsList(int id)
        {
            var userId = User.Identity.GetUserId();
            var teamMember = db.Teammembers.Where(t => t.ApplicationId == userId).FirstOrDefault();
            var foundOrganization = db.Organizations.Where(a => a.OrganizationId == id).FirstOrDefault();
            var foundTeams = db.Teams.Where(a => a.OrganizationId == foundOrganization.OrganizationId).ToList();
            ViewBag.OrganizationName = foundOrganization.Name;
            ViewBag.OrganizationId = foundOrganization.OrganizationId;
            var found = db.TeammemberTeam.Where(a=>a.TeammemberId == teamMember.TeammemberId).FirstOrDefault();
            ViewBag.Junction = found;
            if (found == null)
            {
                return View(foundTeams);
            }
            ViewBag.TeamMemberId = teamMember.TeammemberId;
            return View(foundTeams);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
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
        public ActionResult Edit(Team team, int Id)
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
        public ActionResult Delete(int id)
        {
            if (id == 0)
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
        public ActionResult DeleteConfirmed(int id)
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
