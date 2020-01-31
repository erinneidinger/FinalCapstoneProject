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
    public class TeamMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeamMembers
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var teammember = db.Teammembers.Where(c => c.ApplicationId == userId).ToList();
            return View(teammember);
        }

        // GET: TeamMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember TeamMember = db.Teammembers.Find(id);
            if (TeamMember == null)
            {
                return HttpNotFound();
            }
            return View(TeamMember);
        }
        //public async Task<Meeting> GetLatNLngAsync()
        //{
        //    string requestUri = PrivateKey.URLGeocode + StreetAddress + ",+" + City + "+" + State + PrivateKey.KeyKey + PrivateKey.GoogleAPIKey;
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync(requestUri);
        //    string jsonResult = await response.Content.ReadAsStringAsync();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        GeoCode location = JsonConvert.DeserializeObject<GeoCode>(jsonResult);
        //        Latitude = location.results [0].geometry.location.lat;
        //        Longitude = location.results [0].geometry.location.lng;
        //        return ;
        //    }

        //    db.SaveChanges();
        //    return ;
        //}
        // GET: TeamMembers/Create
        public ActionResult Create()
        {
            TeamMember teammember = new TeamMember();
            return View(teammember);
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeammemberId,FirstName,LastName,StreetAddress,City,State,Email,Latitude,Longitude,ApplicationId")] TeamMember teammember)
        {
            try
            {
                teammember.ApplicationId = User.Identity.GetUserId();
                db.Teammembers.Add(teammember);
                db.SaveChanges();
                return RedirectToAction("AddToJunction");
            }
            catch
            {
                return View();
            }
           
        }

        public ActionResult AddToJunction(TeamMember teammember)
        {
            teammember.ApplicationId = User.Identity.GetUserId();
            var foundTeammember = db.Teammembers.Where(a => a.TeammemberId == teammember.TeammemberId).FirstOrDefault();
            var foundId = db.TeammemberTeam.Where(a => a.TeammemberId == foundTeammember.TeammemberId).FirstOrDefault();
            db.TeammemberTeam.Add(foundId);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TeamMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember TeamMember = db.Teammembers.Find(id);
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
            TeamMember TeamMember = db.Teammembers.Find(id);
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
            TeamMember TeamMember = db.Teammembers.Find(id);
            db.Teammembers.Remove(TeamMember);
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
