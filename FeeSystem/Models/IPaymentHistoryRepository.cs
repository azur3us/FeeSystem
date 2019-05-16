using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeeSystem.Models
{
    public interface IPaymentHistoryRepository
    {
        IEnumerable<PaymentHistory> GetPaymentHistory(Resident resident);
        PaymentHistory GetPaymentHistoryById(int paymentHisotryId);
        PaymentHistory GetLastItem(Resident resident);
    }
}
