using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_.Models;

namespace Project_.Controllers
{
    public class BooksController : Controller
    {
        private MaktabtyEntities6 db = new MaktabtyEntities6();

        // GET: Books

        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
        public ActionResult books_after_login()
        {
            return View(db.Books.ToList());
        }
/*        public ActionResult ViewCollection_1()
        {
            return View(db.Books.ToList());
        }*/
        public ActionResult ViewCollection_1()
        {
            return View(db.Books.ToList());
        }
        public ActionResult ViewCollection_2()
        {
            return View(db.Books.ToList());
        }
        public ActionResult ViewCollection_3()
        {
            return View();
        }
        public ActionResult adminBooks_after_login()
        {
            return View(db.Books.ToList());
        }
        public ActionResult books_before_login()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
       /* public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }*/

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Admin_Name");
            return View();
        }


        public ActionResult Filters()
        {
            Book b = new Book();
            var x = db.Books.ToList();
            var y = x.FindAll(s => s.Genre == "Drama").ToString();
            return View(y);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Book_Name,Genre,Quantity,Cover_Type,Book_Type,AdminID")] Book book, Book Image1)
        {


            using (MaktabtyEntities6 db = new MaktabtyEntities6())
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        string filename = Path.GetFileNameWithoutExtension(Image1.ImageFile.FileName);
                        string extension = Path.GetExtension(Image1.ImageFile.FileName);
                        filename = filename + DateTime.Now.ToString("yymm") + extension;
                        Image1.Image = "~/Images/" + filename;
                        filename = Path.Combine(Server.MapPath("~/Images/"), filename);
                        Image1.ImageFile.SaveAs(filename);
                        db.Books.Add(Image1);
                        db.SaveChanges();
                        return RedirectToAction("adminBooks_after_login");
                    }
                }
                catch (Exception)
                {
                    return View();
                   
                }

                
                
            }


            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Admin_Name", book.AdminID);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewCollection_1(Book b)
        {
            return RedirectToAction("Borrows", "AddToCart");
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Admin_Name", book.AdminID);
            return View(book);
        }

       

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Book_Name,Genre,Image,Quantity,Cover_Type,Book_Type,AdminID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminID = new SelectList(db.Admins, "AdminID", "Admin_Name", book.AdminID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
