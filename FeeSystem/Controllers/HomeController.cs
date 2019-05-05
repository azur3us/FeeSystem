using FeeSystem.Logic;
using FeeSystem.Models;
using FeeSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace FeeSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IPaymentHistoryRepository _paymentHistoryRepository;
        public HomeController(IResidentRepository residentRepository, IPaymentHistoryRepository paymentHistoryRepository)
        {
            _residentRepository = residentRepository;
            _paymentHistoryRepository = paymentHistoryRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            if (this.User.IsInRole("Admin"))
                return IndexAdmin();
            else
                return IndexUser();
        }
        private IActionResult IndexUser()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                throw new Exception("User Id is null");

            var resident = _residentRepository.TakeResidentByUserId(Guid.Parse(userId));
           
            if (resident == null)
                return NotFound();

            return ShowDetails(resident);
        }
        private IActionResult IndexAdmin()
        {
            var residents = _residentRepository.ReturnAllResidents().OrderBy(r => r.PayerNumber);

            var homeVM = new HomeVM()
            {
                Title = "Lista lokatorów:",
                Residents = residents.ToList()
            };
            return View("Index", homeVM);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var resident = _residentRepository.TakeResidentById(id);

            if (resident == null)
                return NotFound();

            return ShowDetails(resident);
        }
        
       private IActionResult ShowDetails(Resident resident)
        {
            var Payments = resident.PaymentDetails(_paymentHistoryRepository);

            return View("Details", (resident, Payments));
        }

    }
}