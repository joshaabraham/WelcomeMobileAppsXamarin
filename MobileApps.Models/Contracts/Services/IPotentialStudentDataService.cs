using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface IPotentialStudentDataService
    {
        Task AddPotentialStudentToSQLiteAsync(IList<PotentialStudent> potentialStudents);
        Task AddPotentialStudentToSQLiteAsync(PotentialStudent potentialStudent);
        Task<IList<PotentialStudent>> GetPotentialStudentFromSQLiteByOrganizationAsync(Organization organizationId);
        Task<bool> AddPotentialStudentToCRM(PotentialStudent lead, string baseAddress, string actionUrl);
	 }
}
