using MobileApps.Models.Contracts.Repository.SQLite;
using MobileApps.Models.Models;

namespace MobileApps.DAL.Repository.SQLite
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
    }
}
