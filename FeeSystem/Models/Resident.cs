using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeeSystem.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal MetersOfFlat { get; set; }
        public int HotWaterConsumption { get; set; }
        public int ColdWaterConsumption { get; set; }
        public int PayerNumber { get; set; }
    }
}