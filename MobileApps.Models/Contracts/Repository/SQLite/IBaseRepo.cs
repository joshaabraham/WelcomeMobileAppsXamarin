using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Models.Models;

namespace MobileApps.DAL.Repository.SQLite
{
    public interface IBaseRepo<T> where T : BaseModel
    {

        Task AddEntitiesAsync(IList<T> obj);
        Task<IList<T>> GetAllEntitiesAsync();
		Task<IList<T>> GetEntitiesByOrganizationAndLanguageAsync(String Organisation, String Language);
        Task<IList<T>> GetEntitiesByOrganizationIDAndLanguageAsync(Guid OrganisationID, String Language);
	}
}
