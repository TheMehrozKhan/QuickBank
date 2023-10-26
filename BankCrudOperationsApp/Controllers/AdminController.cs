using Microsoft.AspNetCore.Mvc;

namespace BankCrudOperationsApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
