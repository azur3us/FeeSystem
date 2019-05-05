using FeeSystem.Models;
using FeeSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FeeSystem.Logic
{
    public static class FeeCalculator
    {
        public static IEnumerable<PaymentDetailsVM> PaymentDetails(this Resident resident, IPaymentHistoryRepository paymentHistoryRepository)
        {
            var list = paymentHistoryRepository.GetPaymentHistory(resident);
            return list.Select(x => x.PaymentDetails());
        }
        public static PaymentDetailsVM PaymentDetails(this PaymentHistory paymentHistory)
        {
            var ret = new PaymentDetailsVM();
            ret.costOfExploitation = paymentHistory.ConnectedResident.MetersOfFlat * paymentHistory.Prices.Exploitation;
            ret.costOfRepairFund = paymentHistory.ConnectedResident.MetersOfFlat * 1.2m;
            ret.costOfHotWaterConsumption = paymentHistory.HotWaterConsumption * 20;
            ret.costOfColdWaterConsumption = paymentHistory.ColdWaterConsumption * 4;
            ret.costOfSewage = (paymentHistory.HotWaterConsumption + paymentHistory.ColdWaterConsumption) * 5.51m;
            ret.costOfCentralHeating = paymentHistory.ConnectedResident.MetersOfFlat * 4;
            ret.menagmentCost = paymentHistory.ConnectedResident.MetersOfFlat * 0.4m;
            ret.paymentHistory = paymentHistory;
                               

            return ret;
        }

        public static bool IsPermitted(this Resident resident, string UserId)
        {
            return resident.ConnectedUser.ToString() == UserId && UserId != null;
        }
       

    }
}
