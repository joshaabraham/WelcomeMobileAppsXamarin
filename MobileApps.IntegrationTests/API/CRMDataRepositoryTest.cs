using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileApps.Models.Models;
using MobileApps.DependencyInjection;
using MobileApps.DAL.Repository.API;
using Microsoft.Practices.Unity;
using System;
using Nito.AsyncEx.UnitTests;
using System.Threading.Tasks;

namespace MobileApps.IntegrationTests.API
{
    /// <summary>
    /// Summary description for CRMDataRepositoryTest
    /// </summary>
    [AsyncTestClass]
    public class CRMDataRepositoryTest
    {
        DependencyInjectionRegister DInjector;
        IUnityContainer _container;

        [TestInitialize]
        public void SetUp()
        {
            DInjector = new DependencyInjectionRegister();
            _container = DInjector.GetCurrentContainer();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetCampusesFromCampusDataServiceTest()
        {  
            //var _repo = _container.Resolve<CampusApiRepository>();
           
            //Organization _organization = new Organization(new Guid(), "montreal");

            //List<Campus> campuses = _repo.GetCampusesByOrganizationAsync(_organization, "en").Result(Task.FromResult<List<Campus>>()));

            //Assert.IsTrue(campuses.Count > 0);
        }

        private async Task<T> Delayed<T>(int milliseconds, T result) {
            await Task.Delay(milliseconds);
            return result;
        } 

        //[TestMethod]
        //public void CitizenshipStatusDataServiceTest()
        //{
        //}
        //[TestMethod]
        //public void InfoLeadDataServiceTest()
        //{
        //}
        //[TestMethod]
        //public void LeadDataServiceTest()
        //{
        //}
        //[TestMethod]
        //public void NationalityDataServiceTest()
        //{
        //}
        //[TestMethod]
        //public void ObjectiveDataServiceTest()
        //{
        //}
        //[TestMethod]
        //public void OccupationDataServiceTest()
        //{
        //}
        //[TestMethod]
        //public void OrganizationDataServiceTest()
        //{
        //}
        //[TestMethod]
        //public void PotentialStudentDataServiceTest()
        //{
        //}
        //[TestMethod]
        //public void StudyInstitutionDataServiceTest()
        //{
        //}
    }
}
