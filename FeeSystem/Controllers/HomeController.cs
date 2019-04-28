using FeeSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeeSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResidentRepository _residentRepository;

        public HomeController(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}