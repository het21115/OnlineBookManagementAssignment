using OnlineBookManagementSystem.Models;
using System.Linq;
using System.Web.Mvc;

namespace OnlineBookManagementSystem.Controllers
{
    public class BookController : Controller
    {
        private BookDbContext db = new BookDbContext();

        // GET: Book
        public ActionResult Index()
        {
            var books = db.Books.ToList();
            ViewBag.BookTypes = db.BookTypes.ToList();
            return View(books);
        }
        [HttpGet]
        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.BookTypes = db.BookTypes.ToList();
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Publishers = db.Publishers.ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                var bookType = db.BookTypes
                        .FirstOrDefault(x => x.bookType_id == b.bookType_id);
                if (bookType.bookType_name == "Fiction")
                {
                    b.Price = b.Price - (b.Price * 10/100);
                }
                db.Books.Add(b);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.BookTypes = db.BookTypes.ToList();
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Publishers = db.Publishers.ToList();

            return View(b);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var book = db.Books.Find(id);
            ViewBag.BookTypes = db.BookTypes.ToList();
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Publishers = db.Publishers.ToList();

            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book b)
        {
            if (ModelState.IsValid)
            {
                var book = db.Books.Find(b.Book_id);

                book.Book_name = b.Book_name;
                book.bookType_id = b.bookType_id;
                book.Author_id = b.Author_id;
                book.Publisher_id = b.Publisher_id;
                book.Publish_date = b.Publish_date;
                book.ISBN_no = b.ISBN_no;
                book.Price = b.Price;

                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.BookTypes = db.BookTypes.ToList();
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Publishers = db.Publishers.ToList();

            return View(b);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        { 
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search(int bookType_id)
        {
            var books = db.Books.Where(x => x.bookType_id == bookType_id).ToList();
            ViewBag.BookTypes = db.BookTypes.ToList();
            return View("Index",books);
        }
    }
}