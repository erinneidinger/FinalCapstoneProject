using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
            var teammember = db.Teammembers.Where(c => c.ApplicationId == userId).FirstOrDefault();
            ViewBag.TeammemberId = teammember.TeammemberId;
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
        //        Latitude = location.results[0].geometry.location.lat;
        //        Longitude = location.results[0].geometry.location.lng;
        //        return;
        //    }

        //    db.SaveChanges();
        //    return;
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
        public ActionResult Create(TeamMember teammember)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                teammember.ApplicationId = userId;
                var foundMember = db.Users.Where(e => e.Id == teammember.ApplicationId).FirstOrDefault();
                teammember.Email = foundMember.Email;
                db.Teammembers.Add(teammember);
                db.SaveChanges();
                ViewBag.TeammemberId = teammember.TeammemberId;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
           
        }
        //create team first, then junction table
        //public ActionResult AddToJunction(TeamMember teammember)
        //{
            
        //    teammember.ApplicationId = User.Identity.GetUserId();
        //    var newTeammember = db.Teammembers.Where(a => a.ApplicationId == teammember.ApplicationId).FirstOrDefault();
        //    var foundTeammember = db.Teammembers.Where(a => a.TeammemberId == newTeammember.TeammemberId).FirstOrDefault();
        //    TeammemberTeam teammemberteam = new TeammemberTeam();
        //    teammemberteam.TeammemberId = foundTeammember.TeammemberId;
        //    db.TeammemberTeam.Add(teammemberteam);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        // GET: TeamMembers/Edit/5
        public ActionResult Edit(int id)
        { 
            TeamMember TeamMember = db.Teammembers.Find(id);
           
            //ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", TeamMember.ApplicationId);
            return View(TeamMember);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeamMember TeamMember, int id)
        {
            if (ModelState.IsValid)
            {
                db.Entry(TeamMember).State = EntityState.Modified;
                db.SaveChanges();
                return View(TeamMember);
            }
            //ViewBag.ApplicationId = new SelectList(db.Users, "Id", "Email", TeamMember.ApplicationId);
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
