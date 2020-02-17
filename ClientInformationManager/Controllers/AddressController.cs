using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInformationManager.Controllers
{
    public class AddressController : Controller
    {
        Models.ClientsEntities db = new Models.ClientsEntities();
        // GET: Address
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            Models.Person person = db.People.SingleOrDefault(p => p.person_id == id);
            return View(person);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            Models.Address address = db.Addresses.SingleOrDefault(a => a.address_id == id);           
            return View(address);
        }

        // GET: Address/Create
        public ActionResult Create(int id)
        {
            ViewBag.id = id;
            ViewBag.countries = db.Countries.Select(c => new SelectListItem() { Value = c.country_code, Text = c.country_name });
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.Address newAddress = new Models.Address()                
                {
                    city = collection["city"],
                    country_code = collection["country_code"],
                    description = collection["description"],
                    person_id = id,
                    prov_state = collection["prov_state"], // stat_prov
                    street = collection["street"], // street
                    zip_postal = collection["zip_postal"] // zip_postal

                };
                db.Addresses.Add(newAddress);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = newAddress.person_id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            Models.Address address = db.Addresses.SingleOrDefault(a => a.address_id == id);
            ViewBag.countries = db.Countries.Select(c => new SelectListItem() { Value = c.country_code, Text = c.country_name });
            return View(address);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.Address address = db.Addresses.SingleOrDefault(a => a.address_id == id);
                address.city = collection["city"];
                address.country_code = collection["country_code"];
                address.description = collection["description"];
                address.prov_state = collection["prov_state"];
                address.city = collection["city"];
                address.zip_postal = collection["zip_postal"];

                return RedirectToAction("Index", new { id = address.address_id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Address address = db.Addresses.SingleOrDefault(a => a.address_id == id);
            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Address address = db.Addresses.SingleOrDefault(a => a.address_id == id);
                db.Addresses.Remove(address);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = address.person_id });
            }
            catch
            {
                return View();
            }
        }
    }
}
