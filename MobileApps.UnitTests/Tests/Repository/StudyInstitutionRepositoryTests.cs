using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileApps.Models.Contracts.Repository;
using MobileApps.IntegrationTests.Moke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApps.IntegrationTests.Tests.Repository
{
    [TestClass]
    public class StudyInstitutionRepositoryTests
    {
        private IStudyInstitutionRepository _repository;
        [TestInitialize]

        public void Initialize()
        {
            _repository = RepositoryMoks.GetMockStudyInstitutionRepository(5).Object;
        }
        public async Task GetCampuses_Return_Campuses_ByOrganization()
        {
            var campuses = await _repository.GetAllStudyInstitutionesAsync();

            Assert.AreEqual(5, campuses.Count);
        }
    }
}
