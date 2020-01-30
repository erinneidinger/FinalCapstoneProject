using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalCapstone.Models;

namespace FinalCapstone.Controllers
{
    public class TeamMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeamMembers
        public ActionResult Index()
        {
            var TeamMembers = db.TeamMembers.Include(t => t.ApplicationUser);
            return View(TeamMembers.ToList());
        }

        // GET: TeamMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember TeamMember = db.TeamMembers.Find(id);
            if (TeamMember == null)
            {
                return HttpNotFound();
            }
            return View(TeamMember);
        }

        //GeoCode GET
        //public async System.Threading.Tasks.Task<Concert> GetLatNLngAsync()
        //{
        //    using (HttpClient client = new HttpClient());
        //    HttpResponseMessage response = await client.GetAsync(url);
        //    string jsonResult = await response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        GeoCode location = JsonConvert.DeserializeObject<GeoCode>(jsonResult);
        //        e.Lat = location.results[0].geometry.location.lat;
        //        e.Lng = location.results[0].geometry.location.lng;
        //        return;
        //    }
        //    db.SaveChanges();
        //    return;
        //}

        // GET: TeamMembers/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,FirstName,LastNameStreetAddress,City,State,Email,Latitude,Longitude,ApplicationId")] TeamMember TeamMember)
        {
            if (ModelState.IsValid)
            {
                db.TeamMembers.Add(TeamMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", TeamMember.ApplicationId);
            return View(TeamMember);
        }

        // GET: TeamMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember TeamMember = db.TeamMembers.Find(id);
            if (TeamMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", TeamMember.ApplicationId);
            return View(TeamMember);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,FirstName,LastNameStreetAddress,City,State,Email,Latitude,Longitude,ApplicationId")] TeamMember TeamMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(TeamMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", TeamMember.ApplicationId);
            return View(TeamMember);
        }

        // GET: TeamMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember TeamMember = db.TeamMembers.Find(id);
            if (TeamMember == null)
            {
                return HttpNotFound();
            }
            return View(TeamMember);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamMember TeamMember = db.TeamMembers.Find(id);
            db.TeamMembers.Remove(TeamMember);
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
