using FeeSystem.Models;
using System;

namespace FeeSystem.Logic
{
    public static class FeeCalculator
    {

        /*
        public static decimal PaymentDetails(this Resident resident)
        {
            decimal summaryOfCosts;
            decimal costOfExploitation = resident.MetersOfFlat * 0.6m;
            decimal costOfRepairFund = resident.MetersOfFlat * 1.2m;
            decimal costOfHowWaterConsumption = resident.HotWaterConsumption * 20;
            decimal costOfColdWaterConsumption = resident.ColdWaterConsumption * 4;
            decimal costOfSewage = (resident.HotWaterConsumption + resident.ColdWaterConsumption) * 5.51m;
            decimal costOfCentralHeating = resident.MetersOfFlat * 4;
            decimal menagmentCost = resident.MetersOfFlat * 0.4m;

            summaryOfCosts = costOfExploitation + costOfRepairFund + costOfHowWaterConsumption + costOfColdWaterConsumption +
                        costOfSewage + costOfCentralHeating + menagmentCost;

            summaryOfCosts = Math.Round(summaryOfCosts, 2);


            return summaryOfCosts;
        }
        */
        public static (decimal costOfExploitation, decimal costOfRepairFund, decimal costOfHotWaterConsumption,
                      decimal costOfColdWaterConsumption, decimal costOfSewage, decimal costOfCentralHeating,
                      decimal menagmentCost, decimal summaryOfCosts) PaymentDetails(this Resident resident)
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


            



            return (costOfExploitation, costOfRepairFund, costOfHotWaterConsumption, costOfColdWaterConsumption, costOfSewage,
                    costOfCentralHeating, menagmentCost, summaryOfCosts);
        }

    }
}
