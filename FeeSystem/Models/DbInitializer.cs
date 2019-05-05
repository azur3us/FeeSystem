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
            new Resident { Name = "Andrzej", Surname = "Kowal", MetersOfFlat = 67.1M, PayerNumber = 1},
            new Resident { Name = "Bartek", Surname = "Kowal", MetersOfFlat = 81.1M, PayerNumber = 2},
            new Resident { Name = "Patryk", Surname = "Kowal", MetersOfFlat = 67.1M, PayerNumber = 3}
            /*
            new Resident { Name = "Marcin", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 5, ColdWaterConsumption = 3, PayerNumber = 4},
            new Resident { Name = "Mateusz", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3, PayerNumber = 5},
            new Resident { Name = "Alicja", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 1, ColdWaterConsumption = 4, PayerNumber = 6},
            new Resident { Name = "Katarzyna", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3, PayerNumber = 7},
            new Resident { Name = "Agnieszka", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 5, ColdWaterConsumption = 3, PayerNumber = 8},
            new Resident { Name = "Natalia", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 1, PayerNumber = 9},
            new Resident { Name = "Rafał", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 5, ColdWaterConsumption = 3, PayerNumber = 10},
            new Resident { Name = "Robert", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 14, ColdWaterConsumption = 3, PayerNumber = 11},
            new Resident { Name = "Przemek", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 1, ColdWaterConsumption = 3, PayerNumber = 12},
            new Resident { Name = "Michał", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3, PayerNumber = 13},
            new Resident { Name = "Sylwester", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 5, ColdWaterConsumption = 3, PayerNumber = 14},
            new Resident { Name = "Małgorzata", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 10, PayerNumber = 15},
            new Resident { Name = "Beata", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 5, ColdWaterConsumption = 3, PayerNumber = 16},
            new Resident { Name = "Anna", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3, PayerNumber = 17},
            new Resident { Name = "Eugeniusz", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 5, ColdWaterConsumption = 3, PayerNumber = 18},
            new Resident { Name = "Leszek", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 1, ColdWaterConsumption = 7, PayerNumber = 19 },
            new Resident { Name = "Leokadia", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 5, ColdWaterConsumption = 3, PayerNumber = 20},
            new Resident { Name = "Maria", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 7, ColdWaterConsumption = 4, PayerNumber = 21},
            new Resident { Name = "Stanisław", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 5, ColdWaterConsumption = 3, PayerNumber = 22},
            new Resident { Name = "Jan", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3, PayerNumber = 23},
            new Resident { Name = "Sylwia", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 7, ColdWaterConsumption = 4, PayerNumber = 24}
          */
            );
            }
            context.SaveChanges();
        }
    }
}
