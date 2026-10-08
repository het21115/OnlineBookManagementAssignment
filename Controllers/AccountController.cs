using OnlineBookManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private BookDbContext db = new BookDbContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email, string Author_password)
        {
            var author = db.Authors.FirstOrDefault(a =>
                a.Email == Email &&
                a.Author_password == Author_password);

            if (author != null)
            {
                Session["author_id"] = author.Author_id;
                Session["author_name"] = author.Author_name;
                Session["author_email"] = author.Email;

                return RedirectToAction("Index", "Book");
            }
            ViewBag.Message = "Invalid email or password.";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}