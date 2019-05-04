using FeeSystem.Models;
using System;

namespace FeeSystem.Logic
{
    public static class FeeCalculator
    {

        public static (decimal costOfExploitation, decimal costOfRepairFund, decimal costOfHotWaterConsumption,
                      decimal costOfColdWaterConsumption, decimal costOfSewage, decimal costOfCentralHeating,
                      decimal menagmentCost, decimal summaryOfCosts, string summaryOfCostsInWords) PaymentDetails(this Resident resident)
        {
            decimal costOfExploitation = resident.MetersOfFlat * 0.6m;
            decimal costOfRepairFund = resident.MetersOfFlat * 1.2m;
            decimal costOfHotWaterConsumption = resident.HotWaterConsumption * 20;
            decimal costOfColdWaterConsumption = resident.ColdWaterConsumption * 4;
            decimal costOfSewage = (resident.HotWaterConsumption + resident.ColdWaterConsumption) * 5.51m;
            decimal costOfCentralHeating = resident.MetersOfFlat * 4;
            decimal menagmentCost = resident.MetersOfFlat * 0.4m;

            
            decimal summaryOfCosts = costOfExploitation + costOfRepairFund + costOfHotWaterConsumption + costOfColdWaterConsumption +
                        costOfSewage + costOfCentralHeating + menagmentCost;

            int zlote = (int)Math.Floor(summaryOfCosts);
            int grosze = (int)((summaryOfCosts - zlote) * 100);

            summaryOfCosts = zlote + grosze * 0.01m;

            string summaryOfCostsInWords = (String.Format("{0} {1}, {2} {3}",
                AmountInWords.LiczbaSlownie(zlote),
                AmountInWords.WalutaSlownie(zlote, "PLN"),
                AmountInWords.LiczbaSlownie(grosze),
                AmountInWords.WalutaSlownie(grosze, ".PLN")));


            return (costOfExploitation, costOfRepairFund, costOfHotWaterConsumption, costOfColdWaterConsumption, costOfSewage,
                    costOfCentralHeating, menagmentCost, summaryOfCosts, summaryOfCostsInWords);
        }

       

    }
}
