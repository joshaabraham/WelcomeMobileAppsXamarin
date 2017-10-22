using System;
namespace MobileApps.DAL
{
    public interface IReachability
    {
        bool IsHostReachable(string host);
    }
}
