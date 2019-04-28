using FeeSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            ViewBag.Title = "Lista lokatorów:";

            var residents = _residentRepository.ReturnAllResidents().OrderBy(r => r.Id);
            return View(residents);
        }
    }
}