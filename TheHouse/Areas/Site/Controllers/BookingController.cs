using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheHouse.Models;

namespace TheHouse.Areas.Site.Controllers
{
    public class BookingController : Controller
    {
        private TheHouseEntities db = new TheHouseEntities();

        // GET: Site/Booking
        //public ActionResult Index()
        //{
        //    //var tbl_Booking = db.tbl_Booking.Include(t => t.tbl_Guest).Include(t => t.tbl_House).Include(t => t.tbl_RoomsDetails);
        //    return View(tbl_Booking.ToList());
        //}

        // GET: Site/Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Booking tbl_Booking = db.tbl_Booking.Find(id);
            if (tbl_Booking == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Booking);
        }

        // GET: Site/Booking/Create
        public ActionResult Create()
        {
            //ViewBag.FK_GuestID = new SelectList(db.tbl_Guest, "G_Id", "G_Name");
            //ViewBag.FK_HouseID = new SelectList(db.tbl_House, "H_ID", "H_Name");
            //ViewBag.FK_RoomID = new SelectList(db.tbl_RoomsDetails, "R_Id", "R_Desc");
            return View();
        }

        // POST: Site/Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tbl_Booking tbl_Booking)
        {
            /*if (ModelState.IsValid)
            {
                db.tbl_Booking.Add(tbl_Booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }*/

            //ViewBag.FK_GuestID = new SelectList(db.tbl_Guest, "G_Id", "G_Name", tbl_Booking.FK_GuestID);
            //ViewBag.FK_HouseID = new SelectList(db.tbl_House, "H_ID", "H_Name", tbl_Booking.FK_HouseID);
            //ViewBag.FK_RoomID = new SelectList(db.tbl_RoomsDetails, "R_Id", "R_Desc", tbl_Booking.FK_RoomID);
            return RedirectToAction("Payment","Payment");
        }

        // GET: Site/Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Booking tbl_Booking = db.tbl_Booking.Find(id);
            if (tbl_Booking == null)
            {
                return HttpNotFound();
            }
           // ViewBag.FK_GuestID = new SelectList(db.tbl_Guest, "G_Id", "G_Name", tbl_Booking.FK_GuestID);
            //ViewBag.FK_HouseID = new SelectList(db.tbl_House, "H_ID", "H_Name", tbl_Booking.FK_HouseID);
            //ViewBag.FK_RoomID = new SelectList(db.tbl_RoomsDetails, "R_Id", "R_Desc", tbl_Booking.FK_RoomID);
            return View(tbl_Booking);
        }

        // POST: Site/Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "B_Id,FK_HouseID,FK_RoomID,FK_GuestID,ArrivalDate,DepartureDate,TotalPerson,BookedBy,Booking_Date,B_Status")] tbl_Booking tbl_Booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.FK_GuestID = new SelectList(db.tbl_Guest, "G_Id", "G_Name", tbl_Booking.FK_GuestID);
            //ViewBag.FK_HouseID = new SelectList(db.tbl_House, "H_ID", "H_Name", tbl_Booking.FK_HouseID);
            //ViewBag.FK_RoomID = new SelectList(db.tbl_RoomsDetails, "R_Id", "R_Desc", tbl_Booking.FK_RoomID);
            return View(tbl_Booking);
        }

        // GET: Site/Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Booking tbl_Booking = db.tbl_Booking.Find(id);
            if (tbl_Booking == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Booking);
        }

        // POST: Site/Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Booking tbl_Booking = db.tbl_Booking.Find(id);
            db.tbl_Booking.Remove(tbl_Booking);
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
