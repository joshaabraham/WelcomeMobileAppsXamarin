using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.Models.Contracts.Repository.SQLite
{
    public interface IPotentialStudentRepository
    {
        Task AddPotentialStudentAsync(IList<PotentialStudent> potentialStudents);
        Task AddPotentialStudentAsync(PotentialStudent potentialStudent);
        Task DeletePotentialStudentAsync(PotentialStudent potentialStudent);
        Task<IList<PotentialStudent>> GetPotentialStudentByOrganizationAsync(Organization potentialStudentId);
    }
}
