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
    public class LeadRepositoryTests
    {
        private ILeadRepository _repository;
        [TestInitialize]

        public void Initialize()
        {
            _repository = RepositoryMoks.GetMockLeadRepository(5).Object;
        }

        [TestMethod]
        public async Task GetLeads_Return_All_Leads()
        {
            var leads = await _repository.GetAllLeadsAsync();

            Assert.AreEqual(5, leads.Count);
        }
    }
}
