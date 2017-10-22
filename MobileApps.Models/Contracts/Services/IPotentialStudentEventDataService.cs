using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface IPotentialStudentEventDataService
    {
		Task AddPotentialStudentEventToSQLiteAsync(PotentialStudentEvent potentialStudent);
        Task AddPotentialStudentEventToSQLiteAsync(IList<PotentialStudentEvent> potentialStudents);
		Task<IList<PotentialStudentEvent>> GetPotentialStudentEventFromSQLiteByOrganizationAsync(Organization organizationId);
        Task<bool> AddPotentialStudentToCRM(PotentialStudentEvent lead, string baseAddress, string actionUrl);
	}
}
