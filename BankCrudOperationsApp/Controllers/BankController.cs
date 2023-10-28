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
                return RedirectToAction("SuccessMessageSignup");
            }
            return View(theusers);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User objUser)
        {
            var obj = _context.Users.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();

            if (obj != null)
            {
                HttpContext.Session.SetString("UserID", obj.UserId.ToString());
                HttpContext.Session.SetString("UserEmail", obj.Email.ToString());
                TempData["ResultOk"] = obj.FirstName + " You logged in successfully"; 
                return RedirectToAction("UserDashBoard");
            }
            else
            {
                TempData["ResultError"] = "Incorrect Email or Password";
                return View();
            }
        }

        public ActionResult SuccessMessageSignup()
        {
            return View();
        }

        public ActionResult UserDashBoard()
        {   
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}