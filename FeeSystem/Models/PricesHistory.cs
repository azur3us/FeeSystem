using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeeSystem.Models
{
    public class PricesHistory
    {
        public int Id { get; set; }
        public DateTime Changed { get; set; }
        public decimal Exploitation { get; set; }
        public decimal RepairFund { get; set; }
        public decimal HotWater { get; set; }
        public decimal ColdWater { get; set; }
        public decimal Sewage { get; set; }
        public decimal CentralHeating { get; set; }
        public decimal Menagment { get; set; }
      
       
    }
}
