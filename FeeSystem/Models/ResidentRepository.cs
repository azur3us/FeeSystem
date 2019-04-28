using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeeSystem.Models
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly AppDbContext _appDbContext;

        public ResidentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Resident> ReturnAllResidents()
        {
            return _appDbContext.Residents;
        }

        public Resident TakeResidentById(int residentId)
        {
            return _appDbContext.Residents.FirstOrDefault(r => r.Id == residentId);
        }
    }
}
