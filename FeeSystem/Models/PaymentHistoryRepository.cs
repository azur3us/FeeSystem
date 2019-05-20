using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FeeSystem.Models
{
    public class PaymentHistoryRepository : IPaymentHistoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public PaymentHistoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<PaymentHistory> GetPaymentHistory(Resident resident)
        {
            return _appDbContext.PaymentHistories.Include(x=>x.PricesHistory).Where(p => p.ConnectedResident == resident).OrderBy(p=>p.Month);
        }
      
        public PaymentHistory GetPaymentHistoryById(int paymentHisotryId)
        {
           
            return _appDbContext.PaymentHistories.Include(x => x.PricesHistory).Include(x =>x.ConnectedResident).FirstOrDefault(x => x.Id == paymentHisotryId);
            
        }
        public PaymentHistory GetLastItem(Resident resident)
        {
            return _appDbContext.PaymentHistories.Include(x => x.PricesHistory).Where(p => p.ConnectedResident == resident).OrderByDescending(p => p.Month).First();
        }
        public PricesHistory GetLastPrices()
        {
            return _appDbContext.PricesHistory.OrderByDescending(x => x.Changed).First();
        }

        public void AddPayment(PaymentHistory paymentHistory)
        {
            paymentHistory.PricesHistory = GetLastPrices();
            _appDbContext.PaymentHistories.Add(paymentHistory);
            _appDbContext.SaveChanges();
        }

        public void EditPayement(PaymentHistory paymentHistory)
        {
            _appDbContext.PaymentHistories.Update(paymentHistory);
            _appDbContext.SaveChanges();
        }

        public void DeletePayment(PaymentHistory paymentHistory)
        {
            _appDbContext.PaymentHistories.Remove(paymentHistory);
            _appDbContext.SaveChanges();
        }
    }
        
}
