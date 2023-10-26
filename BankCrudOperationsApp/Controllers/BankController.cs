using BankCrudOperationsApp.Data;
using BankCrudOperationsApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankCrudOperationsApp.Controllers
{
    public class BankController : Controller
    {
        private readonly TransactionDbContext _context;
        public BankController(TransactionDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(User theusers)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(theusers);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }
            return View(theusers);
        }
    }
}