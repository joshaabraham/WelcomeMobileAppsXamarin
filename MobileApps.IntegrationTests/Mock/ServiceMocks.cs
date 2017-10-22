using System;
using System.Collections.Generic;
using MobileApps.BL.Services;
using MobileApps.Models.Contracts.Repository;
using MobileApps.Models.Models;
using Moq;

namespace MobileApps.IntegrationTests.Moke
{
    public class ServiceMocks
    {
        public static CampusDataService GetMockCityDataService(int count)
        {
            //var list = new List<Campus>();

            //var mockexpenseRepository = new Mock<ICampusRepository>();
            //for (var i = 0; i < count; i++)
            //{
            //    list.Add(new Campus { CampusId = new Guid()});
            //}
            //mockexpenseRepository.Setup(m => m.GetCampusesByOrganizationAsync(It.IsAny<Guid>())).ReturnsAsync(list);

            //var cityDataService = new CampusDataService(mockexpenseRepository.Object);
            //return cityDataService;
        }
    }
}
