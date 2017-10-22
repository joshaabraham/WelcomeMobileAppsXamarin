using SQLite.Net;
using SQLite.Net.Async;

namespace MobileApps.DAL
{
    public interface ISqLite
    {
        void CloseConnection();
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection();
        void DeleteDatabase();
    }
}
