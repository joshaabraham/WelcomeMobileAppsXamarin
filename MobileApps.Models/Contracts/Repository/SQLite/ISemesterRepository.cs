using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Repository.SQLite
{
    public interface ISemesterRepository
    {
		Task AddSemesterAsync(IList<Semester> semesters);
		Task<IList<Semester>> GetSemesterByOrganizationAsync(String Organisation, String Language);
	}
 }
