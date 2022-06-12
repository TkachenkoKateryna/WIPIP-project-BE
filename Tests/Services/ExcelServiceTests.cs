using Domain.Interfaces.Services;
using Domain.Models.Constants;
using Domain.Models.Dtos.Responses;
using Domain.Services.Util;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Tests.Services
{
    public class ExcelServiceTests
    {
        [Fact]
        public void GenerateRiskRegisterXml()
        {
            var projectRisks = new List<RiskResponse>()
            {
                new RiskResponse()
                {
                    Id = "1232",
                    Title = "New Risk",
                    Description = "New Description",
                    RiskCategory = new RiskCategoryResponse
                    {
                        Id = "1234",
                        Title = "New Category"
                    },
                    Impact = Impact.Moderate,
                    Likelihood = Likelihood.Rare
                }
            };

            var riskService = new Mock<IRiskService>();
            riskService.Setup(r => r.GetRisksByProject(It.IsAny<string>()))
                .Returns(projectRisks);
            var stakeholderService = new Mock<IStakeholdersService>();

            var excelService = new ExcelService(riskService.Object, stakeholderService.Object);

            // Act
            var result = excelService.GenerateRiskRegisterXml("25a5ece8-8166-4a28-9252-00e6c619e423");

            result.Should().BeOfType<byte[]>();
        }

        [Fact]
        public void GenerateStakeholderRegisterXml()
        {
            var projectStakeholders = new List<StakeholderResponse>()
            {
                new StakeholderResponse()
                {
                    Id = "1232",
                    Name = "New Name",
                    Category = StakeholderCategory.Internal,
                    CommunicationChannel = CommunicationChannel.Messenger,
                    Influence = StakeholderInfluence.Low,
                    Interest = StakeholderInterest.Low,
                    Payment = Payment.Timely,
                    Role = StakeholderRole.Sponsor,
                    Class = StakeholderClass.KeyPlayer
                }
            };

            var stakeholderService = new Mock<IStakeholdersService>();
            stakeholderService.Setup(r => r.GetStakeholders(It.IsAny<string>()))
                .Returns(projectStakeholders);
            var riskService = new Mock<IRiskService>();

            var excelService = new ExcelService(riskService.Object, stakeholderService.Object);

            // Act
            var result = excelService.GenerateStakeholderRegisterXml("25a5ece8-8166-4a28-9252-00e6c619e423", "Project Name");

            result.Should().BeOfType<byte[]>();
        }

    }
}