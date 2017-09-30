using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OTI_Booking_Platform.Models;

namespace OTI_Booking_Platform.Views
{
    public class forecast_listController : Controller
    {
        private ForecastEntities db = new ForecastEntities();

        // GET: forecast_list
        public ActionResult Index()
        {
            var forecast_list = db.forecast_list.Include(f => f.ClientDetail).Include(f => f.forecast_carrierCode).Include(f => f.forecast_portCode_pod).Include(f => f.forecast_portCode_pol);
            return View(forecast_list.ToList());
        }

        // GET: forecast_list/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            forecast_list forecast_list = db.forecast_list.Find(id);
            if (forecast_list == null)
            {
                return HttpNotFound();
            }
            return View(forecast_list);
        }

        // GET: forecast_list/Create
        public ActionResult Create()
        {
            ViewBag.CNEE_Name = new SelectList(db.ClientDetails, "Client", "Client");
            ViewBag.Carrier_SCAC = new SelectList(db.forecast_carrierCode, "SCAC", "SCAC");
            ViewBag.POD = new SelectList(db.forecast_portCode, "Port_Code", "Port_Code");
            ViewBag.POL = new SelectList(db.forecast_portCode, "Port_Code", "Port_Code");
            return View();
        }

        // POST: forecast_list/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,UID,CNEE_Name,ETD_Week,ETD,Carrier_SCAC,String1,VSL,VOY,S_C,POL_Name,POD_Name,Forecast_TEU,POD_Region,Remarks,Over_Book,CT_Feedback,Booked_TEU,Cancelled_TEU,Balance_TEU,Submit_Time,CT_Time,CAR_Time,String2,Dpt,Team_Leader,Team_Name,POL,POD,OP_Type")] forecast_list forecast_list)
        {
            if (ModelState.IsValid)
            {
                db.forecast_list.Add(forecast_list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CNEE_Name = new SelectList(db.ClientDetails, "Client", "TLUID", forecast_list.CNEE_Name);
            ViewBag.Carrier_SCAC = new SelectList(db.forecast_carrierCode, "SCAC", "SCAC", forecast_list.Carrier_SCAC);
            ViewBag.POD = new SelectList(db.forecast_portCode, "Port_Code", "Port_Name", forecast_list.POD);
            ViewBag.POL = new SelectList(db.forecast_portCode, "Port_Code", "Port_Name", forecast_list.POL);
            return View(forecast_list);
        }

        // GET: forecast_list/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            forecast_list forecast_list = db.forecast_list.Find(id);
            if (forecast_list == null)
            {
                return HttpNotFound();
            }
            ViewBag.CNEE_Name = new SelectList(db.ClientDetails, "Client", "TLUID", forecast_list.CNEE_Name);
            ViewBag.Carrier_SCAC = new SelectList(db.forecast_carrierCode, "SCAC", "SCAC", forecast_list.Carrier_SCAC);
            ViewBag.POD = new SelectList(db.forecast_portCode, "Port_Code", "Port_Name", forecast_list.POD);
            ViewBag.POL = new SelectList(db.forecast_portCode, "Port_Code", "Port_Name", forecast_list.POL);
            return View(forecast_list);
        }

        // POST: forecast_list/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UID,CNEE_Name,ETD_Week,ETD,Carrier_SCAC,String1,VSL,VOY,S_C,POL_Name,POD_Name,Forecast_TEU,POD_Region,Remarks,Over_Book,CT_Feedback,Booked_TEU,Cancelled_TEU,Balance_TEU,Submit_Time,CT_Time,CAR_Time,String2,Dpt,Team_Leader,Team_Name,POL,POD,OP_Type")] forecast_list forecast_list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forecast_list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CNEE_Name = new SelectList(db.ClientDetails, "Client", "TLUID", forecast_list.CNEE_Name);
            ViewBag.Carrier_SCAC = new SelectList(db.forecast_carrierCode, "SCAC", "SCAC", forecast_list.Carrier_SCAC);
            ViewBag.POD = new SelectList(db.forecast_portCode, "Port_Code", "Port_Name", forecast_list.POD);
            ViewBag.POL = new SelectList(db.forecast_portCode, "Port_Code", "Port_Name", forecast_list.POL);
            return View(forecast_list);
        }

        // GET: forecast_list/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            forecast_list forecast_list = db.forecast_list.Find(id);
            if (forecast_list == null)
            {
                return HttpNotFound();
            }
            return View(forecast_list);
        }

        // POST: forecast_list/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            forecast_list forecast_list = db.forecast_list.Find(id);
            db.forecast_list.Remove(forecast_list);
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
