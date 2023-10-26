using BankCrudOperationsApp.Data;
using BankCrudOperationsApp.Models;
using Microsoft.AspNetCore.Http;
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
                TempData["ResultOk"] = "Account Created Successfully!";
                return RedirectToAction("Index");
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
                    return RedirectToAction("UserDashBoard");
                }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {   
            return RedirectToAction("Login");
        }
    }
}