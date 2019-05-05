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
            ret.costOfRepairFund = paymentHistory.ConnectedResident.MetersOfFlat * paymentHistory.Prices.RepairFund;
            ret.costOfHotWaterConsumption = paymentHistory.HotWaterConsumption * paymentHistory.Prices.HotWater;
            ret.costOfColdWaterConsumption = paymentHistory.ColdWaterConsumption * paymentHistory.Prices.ColdWater;
            ret.costOfSewage = (paymentHistory.HotWaterConsumption + paymentHistory.ColdWaterConsumption) * paymentHistory.Prices.Sewage;
            ret.costOfCentralHeating = paymentHistory.ConnectedResident.MetersOfFlat * paymentHistory.Prices.CentralHeating;
            ret.menagmentCost = paymentHistory.ConnectedResident.MetersOfFlat * paymentHistory.Prices.Menagment;
            ret.paymentHistory = paymentHistory;
                               

            return ret;
        }

        public static bool IsPermitted(this Resident resident, string UserId)
        {
            return resident.ConnectedUser.ToString() == UserId && UserId != null;
        }
       

    }
}
