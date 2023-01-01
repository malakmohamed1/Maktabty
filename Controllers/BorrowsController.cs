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
    public class BorrowsController : Controller
    {
        private MaktabtyEntities6 db = new MaktabtyEntities6();

        // GET: Borrows
        public ActionResult Index()
        {
            var borrows = db.Borrows.Include(b => b.Book).Include(b => b.User);
            return View(borrows.ToList());
        }

        public ActionResult AddToCart(int id)
        {
        Book b = db.Books.Find(id);
            
        //Here we check for the quantity of the book if its is sold out.

        if (b.Quantity > 0)
        {
            b.Quantity--;
                
        }
        else
        {
            b.Quantity = 0;
            db.SaveChanges();
            return View();
        }

        if (b != null)
        {
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Book_Name",b.BookID);
            return View(b);
        }
        return View();

        }





        // GET: Borrows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrow borrow = db.Borrows.Find(id);
            if (borrow == null)
            {
                return HttpNotFound();
            }
            return View(borrow);
        }

        // GET: Borrows/Create
       
        
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Book_Name");
            ViewBag.NatID = new SelectList(db.Users, "NatID", "Name");
            return View();
        }

        // POST: Borrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BoorowID,NatID,TakenDate,BookID,BroughtDate,Book_Quantity")] Borrow borrow)
        {
            /*Book b = db.Books.Find(id);*/
            Borrow br = new Borrow();
           /* br.BookID = b.BookID;*/
            if (ModelState.IsValid)
            {
                db.Borrows.Add(borrow);
                db.SaveChanges();
                /*ViewBag.Message = string.Format("The book is reserved and is waiting for your pickup" );*/
                return RedirectToAction("books_after_login","Books");
            }

            ViewBag.BookID = new SelectList(db.Books, "BookID", "Book_Name", borrow.BookID);
            ViewBag.NatID = new SelectList(db.Users, "NatID", "Name", borrow.NatID);
            return View(borrow);
        }

        // GET: Borrows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrow borrow = db.Borrows.Find(id);
            if (borrow == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Book_Name", borrow.BookID);
            ViewBag.NatID = new SelectList(db.Users, "NatID", "Name", borrow.NatID);
            return View(borrow);
        }

        // POST: Borrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BoorowID,NatID,BookID,TakenDate,BroughtDate,Book_Quantity")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Book_Name", borrow.BookID);
            ViewBag.NatID = new SelectList(db.Users, "NatID", "Name", borrow.NatID);
            return View(borrow);
        }

        // GET: Borrows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrow borrow = db.Borrows.Find(id);
            if (borrow == null)
            {
                return HttpNotFound();
            }
            return View(borrow);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Borrow borrow = db.Borrows.Find(id);
            db.Borrows.Remove(borrow);
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
