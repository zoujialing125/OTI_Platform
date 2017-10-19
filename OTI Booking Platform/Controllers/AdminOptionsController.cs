using System;
using System.Linq;
using System.Web.Mvc;
using OTI_Booking_Platform.Models;
using System.Linq.Dynamic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

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

        private JsonResult JsData(Type ModalType, DbSet EntityName)
        {
            var TableHeaders = GetHeaders(ModalType);
            var selector = "new (" + String.Join(", ", TableHeaders) + ")";
            var TableData = EntityName.Select(selector).OrderBy("id");
            return new JsonResult()
            {
                ContentEncoding = Encoding.Default,
                ContentType = "application/json",
                Data = new { data = TableData },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = int.MaxValue
            };
        }

        private List<string> GetHeaders(Type ModalType)
        {
            return ModalType.GetProperties().Where(p => 
                                                    p.PropertyType == typeof(int) || 
                                                    p.PropertyType == typeof(string))
                                            .Select(p => p.Name).ToList();
        }

        // GET: ReferenceTables
        public ActionResult ReferenceTables(string id)
        {
            id = id == null ? "" : id;

            switch (id)
            {
                case "tab-clientDetails":
                    ViewBag.Headers = GetHeaders(typeof(ClientDetail));
                    ViewBag.TableName = "Client Details";
                    break;
                case "tab-clientList":
                    ViewBag.Headers = GetHeaders(typeof(ClientList));
                    ViewBag.TableName = "Client List";
                    break;
                case "tab-COList":
                    ViewBag.Headers = GetHeaders(typeof(COList));
                    ViewBag.TableName = "CO List";
                    break;
                case "tab-SHList":
                    ViewBag.Headers = GetHeaders(typeof(SHList));
                    ViewBag.TableName = "SH List";
                    break;
                case "tab-WHSList":
                    ViewBag.Headers = GetHeaders(typeof(WHSList));
                    ViewBag.TableName = "WHS List";
                    break;
                case "tab-bookMethod":
                    ViewBag.Headers = GetHeaders(typeof(BookMethod));
                    ViewBag.TableName = "Booking Method";
                    break;
                case "tab-brokerList":
                    ViewBag.Headers = GetHeaders(typeof(BrokerList));
                    ViewBag.TableName = "Broker List";
                    break;
                case "tab-carrierCodeList":
                    ViewBag.Headers = GetHeaders(typeof(forecast_carrierCode));
                    ViewBag.TableName = "Carrier Code List";
                    break;
                case "tab-carrierAgentList":
                    ViewBag.Headers = GetHeaders(typeof(CarrierAgentList));
                    ViewBag.TableName = "Carrier Agent List";
                    break;
                case "tab-portCodeList":
                    ViewBag.Headers = GetHeaders(typeof(forecast_portCode));
                    ViewBag.TableName = "Port Code List";
                    break;
                case "tab-MlogList":
                    ViewBag.Headers = GetHeaders(typeof(MLOGEntityList));
                    ViewBag.TableName = "Mlog List";
                    break;
                case "tab-clientDetailsData":
                    return JsData(typeof(ClientDetail), db.ClientDetails);
                case "tab-clientListData":
                    return JsData(typeof(ClientList), db.ClientLists);
                case "tab-COListData":
                    return JsData(typeof(COList), db.COLists);
                case "tab-SHListData":
                    return JsData(typeof(SHList), db.SHLists);
                case "tab-WHSListData":
                    return JsData(typeof(WHSList), db.WHSLists);
                case "tab-bookMethodData":
                    return JsData(typeof(BookMethod), db.BookMethods);
                case "tab-brokerListData":
                    return JsData(typeof(BrokerList), db.BrokerLists);
                case "tab-carrierCodeListData":
                    return JsData(typeof(forecast_carrierCode), db.forecast_carrierCode);
                case "tab-carrierAgentListData":
                    return JsData(typeof(CarrierAgentList), db.CarrierAgentLists);
                case "tab-portCodeListData":
                    return JsData(typeof(forecast_portCode), db.forecast_portCode);
                case "tab-MlogListData":
                    return JsData(typeof(MLOGEntityList), db.MLOGEntityLists);
                default:
                    ViewBag.Headers = GetHeaders(typeof(ClientDetail));
                    break;
            }

            return View();
        }

        //public ActionResult ReferenceTablesData(string id)
        //{
        //    id = id == null ? "" : id;

        //    switch (id)
        //    {
        //        case "tab-clientDetails":
        //            ViewBag.TableInfo = JsData(typeof(ClientList), db.ClientLists);
        //            break;
        //        case "tab-clientList":
        //            ViewBag.TableInfo = JsData(typeof(ClientList), db.ClientLists);
        //            break;
        //        case "tab-COList":
        //            ViewBag.TableInfo = JsData(typeof(COList), db.COLists);
        //            break;
        //        case "tab-SHList":
        //            ViewBag.TableInfo = JsData(typeof(SHList), db.SHLists);
        //            break;
        //        case "tab-WHSList":
        //            ViewBag.TableInfo = JsData(typeof(WHSList), db.WHSLists);
        //            break;
        //        case "tab-bookMethod":
        //            ViewBag.TableInfo = JsData(typeof(BookMethod), db.BookMethods);
        //            break;
        //        case "tab-brokerList":
        //            ViewBag.TableInfo = JsData(typeof(BrokerList), db.BrokerLists);
        //            break;
        //        case "tab-carrierCodeList":
        //            ViewBag.TableInfo = JsData(typeof(forecast_carrierCode), db.forecast_carrierCode);
        //            break;
        //        case "tab-carrierAgentList":
        //            ViewBag.TableInfo = JsData(typeof(CarrierAgentList), db.CarrierAgentLists);
        //            break;
        //        case "tab-portCodeList":
        //            ViewBag.TableInfo = JsData(typeof(forecast_portCode), db.forecast_portCode);
        //            break;
        //        case "tab-MlogList":
        //            ViewBag.TableInfo = JsData(typeof(MLOGEntityList), db.MLOGEntityLists);
        //            break;
        //        default:
        //            ViewBag.TableInfo = JsData(typeof(ClientDetail), db.ClientDetails);
        //            break;
        //    }

        //    return View();
        //}

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
