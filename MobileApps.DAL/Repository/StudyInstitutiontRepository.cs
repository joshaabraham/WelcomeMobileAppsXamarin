using MobileApps.Core.Helpers;
using MobileApps.DAL.Repository;
using MobileApps.Models.Contracts.Repository;
using MobileApps.Models.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(StudyInstitutionRepository))]
namespace MobileApps.DAL.Repository
{
    class StudyInstitutionRepository : IStudyInstitutionRepository
    {

        private static readonly AsyncLock Locker = new AsyncLock();

        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISqLite>().GetAsyncConnection();

        public async Task AddStudyInstitutionesAsync(IList<StudyInstitution> studyInstitutiones)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAllAsync(studyInstitutiones);
            }
        }

        public async Task<IList<StudyInstitution>> GetAllStudyInstitutionesAsync()
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<StudyInstitution>().ToListAsync();
            }
        }

        public async Task<IList<StudyInstitution>> GetStudyInstitutionesByOrganizationAsync(Organization organizationId)
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<StudyInstitution>().Where(c => c.OrganizationId == organizationId.Id).ToListAsync();
            }
        }
    }
}
