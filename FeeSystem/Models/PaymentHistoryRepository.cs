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
            return _appDbContext.PaymentHistories.Where(p => p.ConnectedResident == resident).OrderBy(p=>p.Month);
        }

        
    }
}
