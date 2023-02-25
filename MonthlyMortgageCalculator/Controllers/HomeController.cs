using Microsoft.AspNetCore.Mvc;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.MonthylPayment = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(MonthlyPaymentModel calc)
        {
            if (ModelState.IsValid)
            {
                ViewBag.MonthlyPayment = calc.Calculate().ToString("C2");
            }
            else
            {
                ViewBag.MonthlyPayment = "";
            }

            return View();
        }
    }
}
