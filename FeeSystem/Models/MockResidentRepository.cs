using System.Collections.Generic;
using System.Linq;

namespace FeeSystem.Models
{
    public class MockResidentRepository : IResidentRepository
    {
        private List<Resident> residents;

        public MockResidentRepository()
        {
            if (residents == null)
            {
                LoadResidents();
            }
        }

        private void LoadResidents()
        {
            residents = new List<Resident>
            {
            new Resident { Id = 1, Name = "Andrzej", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Id = 2, Name = "Bartek", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 5, ColdWaterConsumption = 3 },
            new Resident { Id = 3, Name = "Krzysiek", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3},
            new Resident { Id = 4, Name = "Ewa", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Id = 5, Name = "Adam", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Id = 6, Name = "Robert", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Id = 7, Name = "Marcin", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Id = 8, Name = "Pioter", Surname = "Kowal", MetersOfFlat = 67.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Id = 9, Name = "Jan", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 },
            new Resident { Id = 10, Name = "Rafał", Surname = "Kowal", MetersOfFlat = 81.1M, HotWaterConsumption = 2, ColdWaterConsumption = 3 }
        };

        }




        public IEnumerable<Resident> ReturnAllResidents()
        {
            return residents;
        }

        public Resident TakeResidentById(int residentId)
        {
            return residents.FirstOrDefault(r => r.Id == residentId);
        }
    }
}
