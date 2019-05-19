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

            return ShowLast(resident);
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

            return ShowLast(resident);
        }

        private IActionResult ShowDetails(Resident resident)
        {
            var Payments = resident.PaymentDetails(_paymentHistoryRepository);
            return null;//todo zmienić
           // return View("Details", (resident, Payments));
        }
        private IActionResult ShowLast(Resident resident)
        {
            var Payment = resident.PaymentDetail(_paymentHistoryRepository);

            return View("Details", (resident, Payment));
        }



        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Resident resident)
        {
            if (ModelState.IsValid)
            {
                _residentRepository.AddResident(resident);
                return RedirectToAction("Index");
            }
            return View(resident);
        }

        public IActionResult Edit(int Id)
        {
            var resident = _residentRepository.TakeResidentById(Id);
            if (resident == null)
                return NotFound();

            return View(resident);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Resident resident)
        {
            if (ModelState.IsValid)
            {
                _residentRepository.EditResident(resident);
                return RedirectToAction("Index");
            }
            return View(resident);
        }

        public IActionResult Delete(int Id)
        {
            var resident = _residentRepository.TakeResidentById(Id);
            if (resident == null)
                return NotFound();

            return View(resident);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            var resident = _residentRepository.TakeResidentById(Id);
            _residentRepository.DeleteResident(resident);

            return RedirectToAction(nameof(Index));
        }

    }
}