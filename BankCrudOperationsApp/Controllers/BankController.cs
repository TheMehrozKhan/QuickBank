using Microsoft.AspNetCore.Mvc;

namespace BankCrudOperationsApp.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
