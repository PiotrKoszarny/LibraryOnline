using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Library.Controllers
{
    public class AdminController : Controller
    {
        private LibraryContext db = new LibraryContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Addbook()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Book.Add(book);
                db.SaveChanges();
                return RedirectToAction("AddBook");
            }
            else
                return View(book);
        }
        [HttpGet]
        public ActionResult AddReader()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReader(Reader reader)
        {
            if (ModelState.IsValid)
            {
                db.Reader.Add(reader);
                db.SaveChanges();
                return View();
            }
            else
                return View(reader);
        }
        public ActionResult AddOrder()
        {
            ViewBag.ReaderId = new SelectList(db.Reader, "ReaderId", "LastName");
            ViewBag.BookId = new SelectList(db.Book, "BookId", "Title");
            return View();
        }

        [HttpPost]
        public ActionResult AddOrder(Order order, List<int> BookId)
        {
            if (ModelState.IsValid)
            {
                order.OrderBooks = new List<OrderBooks>();

                foreach (var item in BookId)
                {
                    order.OrderBooks.Add(new OrderBooks() { BookId = item, OrderId = order.OrderId });
                }
            
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction("AddOrder");
            }
            else
                return View();
        }
        [HttpGet]
        public ActionResult _SearchBook()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
            return PartialView("_SearchBook",db.Book);
        }
        [HttpPost]
        public ActionResult _SearchBook(SearchBook searchBook)
        {

            if (searchBook.TitleSearch != null)
            {
                var result = from i in db.Book
                             where i.Title.Contains(searchBook.TitleSearch)
                             select i;
                return PartialView("_SearchBook", result);

            }
            else
            {
                return RedirectToAction("AddBook");
            }
        }
        public ActionResult Edit(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddBook");
        }
    }
}
//foreach (var item in BookId)
//                {
//                    new order.OrderBooks()
//                    {
//                        BookId = item,
//                    }
//                }