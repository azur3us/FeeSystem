using System;
using System.Collections.Generic;

namespace FeeSystem.Models
{
    public interface IResidentRepository
    {
        IEnumerable<Resident> ReturnAllResidents();
        Resident TakeResidentById(int residentId);
        Resident TakeResidentByUserId(Guid UserId);
    }
}
