using FeeSystem.Logic;
using FeeSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeeSystem.ViewModels
{
    public class PaymentDetailsVM
    {
        public decimal costOfExploitation { get; set; }
        public decimal costOfRepairFund { get; set; }
        public decimal costOfHotWaterConsumption { get; set; }
        public decimal costOfColdWaterConsumption { get; set; }
        public decimal costOfSewage { get; set; }
        public decimal costOfCentralHeating { get; set; }
        public decimal menagmentCost { get; set; }
        public decimal summaryOfCosts => costOfExploitation + costOfRepairFund + costOfHotWaterConsumption + costOfColdWaterConsumption +
                        costOfSewage + costOfCentralHeating + menagmentCost;
        public PaymentHistory paymentHistory { get; set; }

        public string summaryOfCostsInWords
        {
            get
            {
                int zlote = (int)Math.Floor(summaryOfCosts);
                int grosze = (int)((summaryOfCosts - zlote) * 100);

               return (String.Format("{0} {1}, {2} {3}",
                    AmountInWords.LiczbaSlownie(zlote),
                    AmountInWords.WalutaSlownie(zlote, "PLN"),
                    AmountInWords.LiczbaSlownie(grosze),
                    AmountInWords.WalutaSlownie(grosze, ".PLN")));
            }
        }
    }
}
