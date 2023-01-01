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
    public class AdminsController : Controller
    {
        private MaktabtyEntities6 db = new MaktabtyEntities6();

        // GET: Admins
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
        public ActionResult Admin_Signup()
        {
            return View();
        }
        public ActionResult Admin_after_login()
        {
            return View(db.Admins.ToList());
           
        }
        public ActionResult Admin_homepage()
        {
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin_Signup([Bind(Include = "AdminID,Admin_Name,NationalID,Password")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Edit","Users");
            }

            return View(admin);
        }

        // GET: Admins/Edit/5


        public ActionResult Edit(Admin admin)
        {
            using (MaktabtyEntities6 db = new MaktabtyEntities6())
            {
                try
                {
                    var usr = db.Admins.Single(u => u.NationalID == admin.NationalID);
                    var usr1 = db.Admins.Single(u => u.Password == admin.Password);
                    if (usr != null && usr1 != null)
                    {
                        Session["adminNationalID"] = usr.NationalID.ToString();
                        Session["adminPassword"] = usr1.Password.ToString();

                        return RedirectToAction("adminBooks_after_login","Books");

                    }
                    else
                    {
                        ViewBag.MyMessage("wrong NationalID or password!!");
                       // ModelState.AddModelError("", "wrong email or password");
                    }
                }
                catch (Exception )
                {
             

                   //return View();
                }

            }
            return View();


        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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
