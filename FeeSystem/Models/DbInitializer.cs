using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeeSystem.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Residents.Any())
            {
                context.AddRange(
            new Resident { Name = "Andrzej", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Name = "Bartek", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 5, ColdWaterConsumption = 3 },
            new Resident { Name = "Krzysiek", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Name = "Ewa", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Name = "Adam", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Name = "Robert", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Name = "Marcin", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Name = "Pioter", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Name = "Jan", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 }
            );
            }
            context.SaveChanges();
        }
    }
}
