using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_.Models;

namespace Project_.Controllers
{
    public class UsersController : Controller
    {
        private MaktabtyEntities6 db = new MaktabtyEntities6();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult ContactUs_before()
        {
            return View();
        }
        public ActionResult ContactUs_after()
        {
            return View();
        }
        public ActionResult homepage_after_login()
        {
            return View();
        }
        public ActionResult AboutUs_before()
        {
            return View();
        }
        public ActionResult AboutUs_after()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult HomePage()
        {
            return View();
        }
        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NatID,Name,Address,Phone,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("books_after_login", "Books");
            }

            return View(user);
        }

        // GET: Users/Edit/5


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            
            string x = user.NatID.ToString();
            try
            {
                var usr2 = db.Admins.Single(u => u.NationalID == x);
                if (usr2 != null)
                {
                    return RedirectToAction("adminBooks_after_login", "Books");
                }
            }
            catch (Exception)
            {




                using (MaktabtyEntities6 db = new MaktabtyEntities6())
                {
                    try
                    {

                        var usr = db.Users.Single(u => u.NatID == user.NatID);
                        var usr1 = db.Users.Single(u => u.Password == user.Password);
                        if (usr != null && usr1 != null)
                        {
                            Session["AdminID"] = usr.NatID.ToString();
                            Session["AdminPassword"] = usr1.Password.ToString();

                            return RedirectToAction("books_after_login", "Books");

                        }




                    }
                    catch (Exception)
                    {


                        ModelState.AddModelError("", "wrong email or password  ");
                        // ViewBag.MyMessage("Wrong entry please");

                    }

                }
            }
            
            return View();


        }


        /*public ActionResult Edit(User user)
        {
           
            User idlv = db.Users.Find(id);
            User Passwordlv = db.Users.Find(idlv.Password);
            if (idlv == null)
            {
                return HttpNotFound();
            }
            else if(idlv != null & Passwordlv.Equals(idlv.Password))
            {
                return View("homepage_after_login");
            }

            return View();
            
        }*/

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NatID,Name,Address,Phone,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }*/

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
