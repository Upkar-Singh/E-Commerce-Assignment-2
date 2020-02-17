using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInformationManager.Controllers
{
    public class HomeController : Controller
    {
        Models.ClientsEntities db = new Models.ClientsEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.People);
        }

        public ActionResult Search(string name)
        {
            IEnumerable<Models.Person> result = db.People.Where(p => (p.first_name + " " + p.last_name).Contains(name));        
            return View("Index", result);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Models.Person person = db.People.SingleOrDefault(p => p.person_id == id);
            return View(person);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.Person newPerson = new Models.Person()
                {
                    first_name = collection["first_name"],
                    last_name = collection["last_name"],
                    notes = collection["notes"],
                    gender = collection["gender"],
                };
                // TODO: Add insert logic here
                db.People.Add(newPerson);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            Models.Person person = db.People.SingleOrDefault(p => p.person_id == id);
            return View(person);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.Person person = db.People.SingleOrDefault(p => p.person_id == id);
                person.first_name = collection["first_name"];
                person.last_name = collection["last_name"];
                person.notes = collection["notes"];
                person.gender = collection["gender"];

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Person person = db.People.SingleOrDefault(p => p.person_id == id);
            return View(person);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               
                // TODO: Add delete logic here
                Models.Person person = db.People.SingleOrDefault(p => p.person_id == id);
               
                db.People.Remove(person);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }       
    }


}
