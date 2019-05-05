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
            ret.costOfExploitation = paymentHistory.ConnectedResident.MetersOfFlat * paymentHistory.PricesHistory.Exploitation;
            ret.costOfRepairFund = paymentHistory.ConnectedResident.MetersOfFlat * paymentHistory.PricesHistory.RepairFund;
            ret.costOfHotWaterConsumption = paymentHistory.HotWaterConsumption * paymentHistory.PricesHistory.HotWater;
            ret.costOfColdWaterConsumption = paymentHistory.ColdWaterConsumption * paymentHistory.PricesHistory.ColdWater;
            ret.costOfSewage = (paymentHistory.HotWaterConsumption + paymentHistory.ColdWaterConsumption) * paymentHistory.PricesHistory.Sewage;
            ret.costOfCentralHeating = paymentHistory.ConnectedResident.MetersOfFlat * paymentHistory.PricesHistory.CentralHeating;
            ret.menagmentCost = paymentHistory.ConnectedResident.MetersOfFlat * paymentHistory.PricesHistory.Menagment;
            ret.paymentHistory = paymentHistory;
                               

            return ret;
        }

        public static bool IsPermitted(this Resident resident, string UserId)
        {
            return resident.ConnectedUser.ToString() == UserId && UserId != null;
        }
       

    }
}
