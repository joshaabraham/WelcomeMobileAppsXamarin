using System;
using System.Collections.Generic;
using MobileApps.Models.Contracts.Repository;
using MobileApps.Models.Models;
using Moq;

namespace MobileApps.IntegrationTests.Moke
{
    public class RepositoryMoks
    {
        public static Mock<ICampusRepository> GetMockCampusRepository(int count)
        {
            var list = new List<Campus>();
            var mockCampusRepository = new Mock<ICampusRepository>();
            for (var i = 0; i < count; i++)
            {
                list.Add(new Campus { CampusId = new Guid() });
            }
            mockCampusRepository.Setup(m => m.GetCampusesByOrganizationAsync(It.IsAny<Organization>().Id)).ReturnsAsync(list);
            return mockCampusRepository;
        }

        public static Mock<ILeadRepository> GetMockLeadRepository(int count)
        {
            var list = new List<Lead>();
            var mockLeadRepository = new Mock<ILeadRepository>();
            for (var i = 0; i < count; i++)
            {
                list.Add(new Lead { LeadId = new Guid(), Email = "email@gmail.com", OrganizationId = new Guid(), ActivityId = new Guid() });
            }

            // mock recherche TOUS les Leads
            mockLeadRepository.Setup(m => m.GetAllLeadsAsync()).ReturnsAsync(list);

            // mock recherche par ORGANISATION
            mockLeadRepository.Setup(m => m.GetLeadsByOrganizationAsync(It.IsAny<Organization>().Id)).ReturnsAsync(list);

            // mock recherche par EMAIL
            mockLeadRepository.Setup(m => m.GetLeadsByEmailAsync(It.IsAny<string>())).ReturnsAsync(list);

            // mock recherche par ORGANISATION et EMAIL
            mockLeadRepository.Setup(m => m.GetLeadsByOrganizationAndEmailAsync(It.IsAny<Organization>().Id, It.IsAny<string>())).ReturnsAsync(list);

            // mock recherche par CRM et EMAIL
            mockLeadRepository.Setup(m => m.GetLeadsByCrmAndEmailAsync(It.IsAny<Guid>(), It.IsAny<string>())).ReturnsAsync(list);
            return mockLeadRepository;


        }

        public static Mock<IStudyInstitutionRepository> GetMockStudyInstitutionRepository(int count)
        {
            var list = new List<StudyInstitution>();
            var mockStudyInstitutionRepository = new Mock<IStudyInstitutionRepository>();
            for (var i = 0; i < count; i++)
            {
                list.Add(new StudyInstitution { StudyInstitutionId = new Guid(), Name = "Lycee Lacordaire" });
            }
            mockStudyInstitutionRepository.Setup(m => m.GetAllStudyInstitutionesAsync()).ReturnsAsync(list);
            mockStudyInstitutionRepository.Setup(m => m.GetStudyInstitutionesByOrganizationAsync(It.IsAny<Organization>().Id)).ReturnsAsync(list);


            return mockStudyInstitutionRepository;
        }

        public static Mock<ICitizenShipCountryRepository> GetMockCitizenShipCountryRepository(int count)
        {
            var list = new List<CitizenShipCountry>();
            var mockCitizenShipCountryRepository = new Mock<ICitizenShipCountryRepository>();
            for (var i = 0; i < count; i++)
            {
                list.Add(new CitizenShipCountry { CitizenShipCountryId = new Guid(), CountryName = "Belgique", OrganizationId = new Organization().Id });
            }
            mockCitizenShipCountryRepository.Setup(m => m.GetAllCitizenShipCountryAsync()).ReturnsAsync(list);
            mockCitizenShipCountryRepository.Setup(m => m.GetCitizenShipCountryByOrganizationAsync(It.IsAny<Organization>().Id)).ReturnsAsync(list);

            return mockCitizenShipCountryRepository;
        }
    }
}
