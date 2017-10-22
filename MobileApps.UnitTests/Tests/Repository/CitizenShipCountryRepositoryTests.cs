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
    public class CitizenShipCountryRepositoryTests
    {
        private ICitizenShipCountryRepository _repository;
        [TestInitialize]
        public void Initialize()
        {
            _repository = RepositoryMoks.GetMockCitizenShipCountryRepository(5).Object;
        }

        [TestMethod]
        public async Task GetCitizenShipCountryes_Return_All_CitizenShipCountryes()
        {
            var citizenShipCountryes = await _repository.GetAllCitizenShipCountryAsync();

            Assert.AreEqual(5, citizenShipCountryes.Count);
        }
    }
}
