using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileApps.Models.Contracts.Repository;
using MobileApps.Models.Models;
using MobileApps.IntegrationTests.Moke;
using System;

namespace MobileApps.IntegrationTests.Tests.Repository
{
    [TestClass]
    public class CampusRepositoryTests
    {
        private ICampusRepository _repository;
        [TestInitialize]
        public void Initialize()
        {
            _repository = RepositoryMoks.GetMockCampusRepository(5).Object;
        }

        [TestMethod]
        public async Task GetCampuses_Return_Campuses_ByOrganization()
        {
            Guid currentOrg = new Guid();
            var campuses = await _repository.GetCampusesByOrganizationAsync(currentOrg);

            Assert.AreEqual(5, campuses.Count);
        }
    }
}
