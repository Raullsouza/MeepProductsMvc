using MeepProductsMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeepProductsMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}