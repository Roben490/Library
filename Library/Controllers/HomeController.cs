using Library.DAL;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Libery> liberies = Data.Get.Lliberies.ToList();
            return View(liberies);
        }

        public IActionResult CreateLibery(Libery libery)
        {
            Data.Get.Add(libery);
            //שמירת השינויים 
            Data.Get.SaveChanges();
            //החזר של הדף של רשימת החברים עם החבר הנוסף
            return RedirectToAction("index");
        }

        public IActionResult AddShelf(int id)
        {
            ViewBag.id = id;
            return View(new Shelf());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddShelfToLibery(Shelf shelf)
        {
            Libery? lfbb = Data.Get.Lliberies.FirstOrDefault(l=> l.Id == shelf.LibId);
            if (lfbb == null)
            {
                return NotFound();
            }
            shelf.liberies = lfbb;
            Data.Get.shelves.Add(shelf);
            Data.Get.SaveChanges();
            return RedirectToAction("shelfView");
        }

        public IActionResult shelfView()
        {
            List<Shelf> shelves = Data.Get.shelves.ToList();
            return View(shelves); 
        }

        public IActionResult AddBook(int id)
        {
            ViewBag.id = id;
            return View(new Book());
        }

        public IActionResult AddBookToLib(Book book)
        {
            Shelf? slbb = Data.Get.shelves.FirstOrDefault(l => l.Id == book.slfid);
            if (slbb == null)
            {
                return NotFound();
            }
            if (book.Name == null)
            {
                return RedirectToAction("AddBook");
            }
            if (book.High > slbb.High)
            {
                return RedirectToAction("AddBook");
            }
            if (book.High < (slbb.High - 10))
            {
                TempData["name"] = "הספר נכנס למדף, אך הינו נמוך. ";
            }

            book.shelf = slbb;
            Data.Get.books.Add(book);
            Data.Get.SaveChanges();
            return RedirectToAction("index");
        }

       
        public void re()
        {
            int numOfLibery = Data.Get.Lliberies.Count();
        }

        public IActionResult bookViwe() 
        {
            List<Book> books = Data.Get.books.ToList();
            return View(books); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
