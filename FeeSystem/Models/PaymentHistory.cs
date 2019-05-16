using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeeSystem.Models
{
    public class PaymentHistory
    {
        public int Id { get; set; }
        public Resident ConnectedResident { get; set; }
        public DateTime Month { get; set; }
        public int HotWaterConsumption { get; set; }
        public int ColdWaterConsumption { get; set; }
        public PricesHistory PricesHistory { get; set; }
        public bool PaymentStatus { get; set; }

    }
}
