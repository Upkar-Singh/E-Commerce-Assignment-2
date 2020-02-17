using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInformationManager.Controllers
{
    public class ContactController : Controller
    {
        Models.ClientsEntities db = new Models.ClientsEntities();
        // GET: Contact
        public ActionResult Index(int id)
        {
            Models.Person person = db.People.SingleOrDefault(p => p.person_id == id);
            return View(person);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            Models.Contact contact = db.Contacts.SingleOrDefault(c => c.contact_id == id);
            return View(contact);
        }

        // GET: Contact/Create
        public ActionResult Create(int id)
        {
            ViewBag.person = db.People.SingleOrDefault(p => p.person_id == id);
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.Contact newContact = new Models.Contact()
                {
                    person_id = id,
                    type = collection["type"],
                    info = collection["info"]                    
                };
                db.Contacts.Add(newContact);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = newContact.person_id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            Models.Contact contact = db.Contacts.SingleOrDefault(c => c.contact_id == id);

            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.Contact contact = db.Contacts.SingleOrDefault(c => c.contact_id == id);
                contact.info = collection["info"];
                contact.type = collection["type"];

                db.SaveChanges();

                return RedirectToAction("Index", new { id = contact.person_id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Contact contact = db.Contacts.SingleOrDefault(c => c.contact_id == id);
            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Contact contact = db.Contacts.SingleOrDefault(c => c.contact_id == id);
                db.Contacts.Remove(contact);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = contact.person_id});
            }
            catch
            {
                return View();
            }
        }
    }
}
