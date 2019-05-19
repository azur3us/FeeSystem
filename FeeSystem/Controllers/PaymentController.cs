using FeeSystem.Logic;
using FeeSystem.Models;
using FeeSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace FeeSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentHistoryRepository _paymentHistoryRepository;
        private readonly IResidentRepository _residentRepository;

        public PaymentController(IPaymentHistoryRepository paymentHistoryRepository, IResidentRepository residentRepository)
        {
            _paymentHistoryRepository = paymentHistoryRepository;
            _residentRepository = residentRepository;
        }
        public IActionResult Transfer(int paymentHistoryId)
        {
            var paymentHistory = _paymentHistoryRepository.GetPaymentHistoryById(paymentHistoryId);
            var resident = _residentRepository.TakeResidentById(paymentHistory.ConnectedResident.Id);
            return View((resident, paymentHistory.PaymentDetails()));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PaymentHistory paymentHistory)
        {
            if (ModelState.IsValid)
            {
                _paymentHistoryRepository.AddPayment(paymentHistory);
                return RedirectToAction("Index");
            }
            return View(paymentHistory);
        }

        public IActionResult Edit(int Id)
        {
            var payment = _paymentHistoryRepository.GetPaymentHistoryById(Id);
            if (payment == null)
                return NotFound();

            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PaymentHistory paymentHistory)
        {
            if (ModelState.IsValid)
            {
                _paymentHistoryRepository.EditPayement(paymentHistory);
                return RedirectToAction("Index", "Home");
            }
            return View(paymentHistory);
        }

        public IActionResult Delete(int Id)
        {
            var payment = _paymentHistoryRepository.GetPaymentHistoryById(Id);
            if (payment == null)
                return NotFound();

            return View(payment);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            var payment = _paymentHistoryRepository.GetPaymentHistoryById(Id);
            _paymentHistoryRepository.DeletePayment(payment);

            return RedirectToAction("Index");
        }
    }
}