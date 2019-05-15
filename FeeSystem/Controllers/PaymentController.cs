using FeeSystem.Logic;
using FeeSystem.Models;
using FeeSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
    }
}