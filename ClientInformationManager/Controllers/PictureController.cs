using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInformationManager.Controllers
{
    public class PictureController : Controller
    {
        Models.ClientsEntities db = new Models.ClientsEntities();
        // GET: Picture
        public ActionResult Index(int id) // person_id -> Session["user_id"]
        {
            int id = int.Parse(Session["user_id"].ToString());
            Models.Person person = db.People.SingleOrDefault(p => p.person_id == id);            
            return View(person); // list of pictures
        }

        // GET: Picture/Details/5
        public ActionResult Details(int id)
        {
            Models.Picture picture = db.Pictures.SingleOrDefault(p => p.picture_id == id);
            return View(picture);
        }

        // GET: Picture/Create
        public ActionResult Create(/*int id*/)
        {
            int id = int.Parse(Session["user_id"].ToString());
            ViewBag.person = db.People.SingleOrDefault(p => p.person_id == id);
            return View();
        }

        // POST: Picture/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection, HttpPostedFileBase newPicture)
        {
            try
            {
                // TODO: Add insert logic here
                // mime type checking
                string[] types = { "image/gif", "image/jpeg", "image/png" };

                if (newPicture != null 
                    && newPicture.ContentLength > 0
                    && types.Contains(newPicture.ContentType))
                {
                   

                    Models.Picture newPic = new Models.Picture()
                    {
                        caption = collection["caption"],
                        time_info = collection["time_info"],
                        loc_info = collection["loc_info"],
                        relative_path = SavePicture(newPicture),
                        person_id = id
                    };
                    db.Pictures.Add(newPic);
                    db.SaveChanges();                    
                }
                
                return RedirectToAction("Index", new { id = id });               
            }
            catch
            {
                return View();
            }
        }

        public ActionResult makeThisProfile(int id)
        {
            Models.Picture picture = db.Pictures.SingleOrDefault(p => p.picture_id == id);
            picture.Person.picture_id = id;
            db.SaveChanges();

            return RedirectToAction("Index", new { id = picture.person_id });
        }

        // GET: Picture/Edit/5
        public ActionResult Edit(int id)
        {
            //authorization based on ownership
            Models.Picture picture = db.Pictures.SingleOrDefault(p => p.picture_id == id);
            int myId = int.Parse(Session["user_id"].ToString());
            if (picture.person_id != myId)
            {
                return RedirectToAction("Index");
            }
            return View(picture);
        }

        // POST: Picture/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, HttpPostedFileBase newPicture)
        {
            try
            {
                // TODO: Add update logic here
                Models.Picture picture = db.Pictures.SingleOrDefault(p => p.picture_id == id);

                // mime type checking
                string[] types = { "image/gif", "image/jpeg", "image/png" };

                picture.caption = collection["caption"];
                picture.time_info = collection["time_info"];
                picture.loc_info = collection["loc_info"];                

                if (newPicture != null
                    && newPicture.ContentLength > 0
                    && types.Contains(newPicture.ContentType))
                {
                    DeletePicture(picture.relative_path);

                    picture.relative_path = SavePicture(newPicture);                                
                }
                db.SaveChanges();
                return RedirectToAction("Index", new { id = picture.person_id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Picture/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Picture picture = db.Pictures.SingleOrDefault(p => p.picture_id == id);
            return View(picture);
        }

        // POST: Picture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Picture picture = db.Pictures.SingleOrDefault(p => p.picture_id == id);
                if (picture.Person.picture_id == id)
                {
                    picture.Person.picture_id = null;                   
                }
                DeletePicture(picture.relative_path);
                db.Pictures.Remove(picture);                
                db.SaveChanges();

                return RedirectToAction("Index", new { id = picture.person_id });
            }
            catch
            {
                return View();
            }
        }

        public string SavePicture(HttpPostedFileBase newPicture)
        {
            Guid g = Guid.NewGuid();
            string filename = g + Path.GetExtension(newPicture.FileName);
            string path = Server.MapPath("~/Images/");
            path = Path.Combine(path, filename);
            newPicture.SaveAs(path);
            return filename;
        }
        public void DeletePicture(string filename)
        {
            string path = Server.MapPath("~/Images/" + filename);
            System.IO.File.Delete(path);
        }
    }
}
