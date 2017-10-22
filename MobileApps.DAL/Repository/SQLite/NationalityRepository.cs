using MobileApps.Models.Models;
using MobileApps.Models.Contracts.Repository.SQLite;

namespace MobileApps.DAL.Repository.SQLite
{
    public class NationalityRepository : BaseRepository<Country>, INationalityRepository
    {
    }
}
