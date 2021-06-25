using baitap2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace baitap2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String HelloTeacher()
        {
            return "Hello Kieu Anh Phat";
        }
        public string HelloTeacher(string university)
        {
            return "Hello Kieu Anh Phat - University:" + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML & CSS3 The Complete Manual - Author Book 1");
            books.Add("HTML & CSS Responsive web Design cookbook -  - Author Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Book 2");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", "Author Name Book 1", "/Content/images/hinh1.jpg"));
            books.Add(new Book(2, "HTML5 & Responsive web Design cookbook", "Author Name Book 2", "/Content/images/hinh2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5 ", "Author Name Book 3", "/Content/images/hinh3.jpg"));

            return View(books);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", " Author Name Book 1 ", "/Content/images/hinh1.jpg"));
            books.Add(new Book(2, "HTML5 & Responsive web Design cookcook ", " Author Name Book 2", "/Content/images/hinh2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5 - Author Name Book 2", "Author Name Book 3", "/Content/images/hinh3.jpg"));

            if (id == null) 
            {
                foreach (Book b in books)
                {
                    if (b.Id == id)
                    {
                        b.Title = Title;
                        b.Author = Author;
                        b.ImageCover = ImageCover;
                        break;
                    }
                }
                return View("ListBookModel", books);
            }
            return HttpNotFound();

        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Title,Author,ImageCover")] Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete Manual", " Author Name Book 1 ", "/Content/images/hinh1.jpg"));
            books.Add(new Book(2, "HTML5 & Responsive web Design cookcook ", " Author Name Book 2", "/Content/images/hinh2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5 - Author Name Book 2", "Author Name Book 3", "/Content/images/hinh3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    //thêm sách
                    books.Add(book);
                }
            }
            catch (RetryLimitExeededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            //trả về 
            return View("ListBookModel", books);
        }

    }
}