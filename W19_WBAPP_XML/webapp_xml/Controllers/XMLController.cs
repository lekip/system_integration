using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace webapp_xml.Controllers
{
    public class XMLController : Controller
    {
        // GET: XML
        public ActionResult Index()
        {

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            XmlDocument document = new XmlDocument();
            document.LoadXml("CD_LIST.xml"); //Vigtigt!
            document.Validate(settings);
                                

            return View();
        }

        // GET: XML/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: XML/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: XML/Create
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

        // GET: XML/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: XML/Edit/5
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

        // GET: XML/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: XML/Delete/5
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
