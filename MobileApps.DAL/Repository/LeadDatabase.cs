using MobileApp.DL;
using MobileApps.Models.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MobileApps.DAL.Repository
{
    public class LeadDatabase
    {
        SQLiteConnection database;
        static object locker = new object();

        public LeadDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Lead>();
        }
        public Guid SaveLead(Lead lead)
        {
            lock (locker)
            {
                // CHECK IF LEAD EXISTS
                if (lead.ActivityId != Guid.Empty)
                {
                    // UPDATE LEAD 
                    database.Update(lead);
                    return lead.ActivityId;
                }
                else
                {
                    // ADD LEAD
                    database.Insert(lead);
                    return lead.ActivityId;
                }
            }
        }
        public IEnumerable<Lead> GetLeads()
        {
            lock (locker)
            {
                return (
                    from l in database.Table<Lead>()
                        select l).ToList();
            }
        }
        public Lead GetLead(Guid id)
        {
            lock (locker)
            {
                return database.Table<Lead>().Where(c => c.ActivityId == id).FirstOrDefault();
            }
        }
        public int DeleteLead(Guid id)
        {
            lock (locker)
            {
                return database.Delete<Lead>(id);
            }
        }
    }
}
