using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTI_Booking_Platform.Models;

namespace OTI_Booking_Platform.Controllers
{
    public class AdminOptionsController : Controller
    {
        private ForecastEntities db = new ForecastEntities();
        private string[] tableNames = new string[]
        {
            "tab-clientDetails",
            "tab-clientList",
            "tab-COList",
            "tab-SHList",
            "tab-WHSList",
            "tab-bookMethod",
            "tab-brokerList",
            "tab-carrierCodeList",
            "tab-carrierAgentList",
            "tab-portCodeList",
            "tab-MlogList"
        };

        // GET: ReferenceTables
        public ActionResult ReferenceTables(string id)
        {
            id = id == null ? "" : id;
            switch (id)
            {
                case "tab-clientDetails":
                    ViewBag[id] = db.ClientDetails.ToList();
                    break;
                case "tab-clientList":
                    ViewData[id] = db.ClientLists.ToList();
                    break;
                case "tab-COList":
                    ViewData[id] = db.COLists.ToList();
                    break;
                case "tab-SHList":
                    ViewData[id] = db.SHLists.ToList();
                    break;
                case "tab-WHSList":
                    ViewData[id] = db.WHSLists.ToList();
                    break;
                case "tab-bookMethod":
                    ViewData[id] = db.BookMethods.ToList();
                    break;
                case "tab-brokerList":
                    ViewData[id] = db.BrokerLists.ToList();
                    break;
                case "tab-carrierCodeList":
                    ViewData[id] = db.forecast_carrierCode.ToList();
                    break;
                case "tab-carrierAgentList":
                    ViewData[id] = db.CarrierAgentLists.ToList();
                    break;
                case "tab-portCodeList":
                    ViewData[id] = db.forecast_portCode.ToList();
                    break;
                case "tab-MlogList":
                    ViewData[id] = db.MLOGEntityLists.ToList();
                    break;
                default:
                    ViewData[id] = db.ClientDetails.ToList();
                    break;
            }

            return View("ReferenceTables");
        }

        // GET: ReferenceTables/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReferenceTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferenceTables/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReferenceTables/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReferenceTables/Edit/5
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

        // GET: ReferenceTables/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReferenceTables/Delete/5
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
