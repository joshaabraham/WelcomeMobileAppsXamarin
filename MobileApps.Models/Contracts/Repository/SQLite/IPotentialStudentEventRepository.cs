using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Repository.SQLite
{
    public interface IPotentialStudentEventRepository
    {
		Task AddPotentialStudentEventAsync(IList<PotentialStudentEvent> potentialStudents);
		Task AddPotentialStudentEventAsync(PotentialStudentEvent potentialStudent);
		Task DeletePotentialStudentEventAsync(PotentialStudentEvent potentialStudent);
		Task<IList<PotentialStudentEvent>> GetPotentialStudentEventByOrganizationAsync(Organization potentialStudentId);
    }
}
