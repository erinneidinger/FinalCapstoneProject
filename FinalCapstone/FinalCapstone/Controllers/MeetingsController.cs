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
    public class MeetingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Meetings
        public ActionResult Index()
        {
            var meetings = db.Meetings.Include(m => m.team);
            return View(meetings.ToList());
        }

        // GET: Meetings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        public async Task<Meeting> GetLatNLngAsync(Meeting meeting)
        {
            string requestUri = KeyPrivate.URLGeocode + meeting.StreetAddress + ",+" + meeting.City + "+" + meeting.State + KeyPrivate.KeyKey + KeyPrivate.GoogleAPIKey;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(requestUri);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                GeoCode location = JsonConvert.DeserializeObject<GeoCode>(jsonResult);
                meeting.Latitude = location.results[0].geometry.location.lat.ToString();
                meeting.Longitude = location.results[0].geometry.location.lng.ToString();
                return meeting;
            }

            db.SaveChanges();
            return meeting;
        }

        // GET: Meetings/Create
        public ActionResult Create()
        {
            Meeting meeting = new Meeting();
            return View(meeting);
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,StreetAddress,City,State,Bio,TeamId")] TeamMember teammember)
        {
            try
            {

                teammember.ApplicationId = User.Identity.GetUserId();
                var member = db.TeammemberTeam.Where(a => a.TeammemberId == teammember.TeammemberId).FirstOrDefault();
                var foundTeam = db.TeammemberTeam.Where(a=> a.TeamId == member.TeamId).FirstOrDefault();
                var foundMeeting = db.Meetings.Where(a => a.TeamId == foundTeam.TeamId).FirstOrDefault();
                foundMeeting = await GetLatNLngAsync(foundMeeting);
                db.Meetings.Add(foundMeeting);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Meetings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", meeting.TeamId);
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationId,Time,StreetAddress,City,State,Latitude,Longitude,TeamId")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meeting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name", meeting.TeamId);
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meeting meeting = db.Meetings.Find(id);
            if (meeting == null)
            {
                return HttpNotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting meeting = db.Meetings.Find(id);
            db.Meetings.Remove(meeting);
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
