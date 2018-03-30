using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext db = new LibraryContext();
        [HttpGet]
        public ActionResult Index()
        {

            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
            return View(db.Book);
        }
        [HttpPost]
        public ActionResult Index(SearchBook searchBook, Category category)
        {
            //var books;
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");

            if (searchBook.TitleSearch != null)
            {
                var books = from i in db.Book
                            where i.CategoryId.Equals(category.CategoryId)
                            || i.Title.Contains(searchBook.TitleSearch)
                            select i;
                if (books.Count() == 0)
                    return RedirectToAction("Index");
                return View(books);
            }
            else
            {
                var books = from i in db.Book
                            where i.CategoryId.Equals(category.CategoryId)
                            select i;
                return View(books);

            }           
        }
        public ActionResult Register(Reader reader)
        {
            if(ModelState.IsValid)
            {
                db.Reader.Add(reader);
                db.SaveChanges();
                return View();
            }

            return View("Index");
        }
    }
}