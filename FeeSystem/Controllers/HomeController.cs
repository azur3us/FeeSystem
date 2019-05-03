using FeeSystem.Logic;
using FeeSystem.Models;
using FeeSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

            var residents = _residentRepository.ReturnAllResidents().OrderBy(r => r.Id);

            var homeVM = new HomeVM()
            {
                Title = "Lista lokatorów:",
                Residents = residents.ToList()
            };
            return View(homeVM);
        }
        
        [Authorize]
        public IActionResult Details(int id)
        {
            var resident = _residentRepository.TakeResidentById(id);
            resident.PaymentDetails();


            if (resident == null)
                return NotFound();
            return View(resident);
        }
        
       

    }
}