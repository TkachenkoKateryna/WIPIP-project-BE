using Domain.Interfaces.Repositories;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Entities;
using Domain.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Tests.Mapper;
using Xunit;

namespace Tests.Services
{
    public class AssumptionsServiceTests
    {
        [Fact]
        public void CreateAssumption()
        {
            var assumptions = new List<Assumption>();
            var mockAssumptionRep = new Mock<IRepository<Assumption>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockAssumptionRep.Setup(m => m.FindWithDeleted(It.IsAny<Expression<Func<Assumption, bool>>>(), null))
                .Returns(assumptions);
            mockAssumptionRep.Setup(m => m.Find(It.IsAny<Expression<Func<Assumption, bool>>>(), null))
               .Returns(assumptions);
            mockAssumptionRep.Setup(m => m.Create(It.IsAny<Assumption>()))
                .Callback(() =>
                {
                    assumptions.Add(new Assumption
                    {
                        Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                        Description = "frkefjgs",
                        ProjectId = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e4c0")
                    });
                });

            mockUnitOfWork.Setup(m => m.GetRepository<Assumption>())
             .Returns(mockAssumptionRep.Object);

            var assumptionService = new AssumptionsService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            var result = assumptionService.AddAssumption(It.IsAny<AssumptionRequest>());

            // Assert
            var assumptionResponse =
              new AssumptionResponse
              {
                  Id = "25a5ece8-8166-4a28-9252-00e6c619e423",
                  Description = "frkefjgs",
                  ProjectId = "25a5ece8-8166-4a28-9252-00e6c619e4c0"
              };

            result.Should().BeEquivalentTo(assumptionResponse);
        }

        [Fact]
        public void UpdateAssumption()
        {

            var assumptions = new List<Assumption>()
                {
                     new Assumption
                    {
                        Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                        Description = "frkefjgs",
                        ProjectId = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e4c0")
                    }
                };

            var mockAssumptionRep = new Mock<IRepository<Assumption>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockAssumptionRep.Setup(m => m.Find(It.IsAny<Expression<Func<Assumption, bool>>>(), null))
                .Returns(assumptions);
            mockAssumptionRep.Setup(m => m.Update(It.IsAny<Assumption>()))
                .Callback(() =>
                {
                    assumptions.First().Description = "frkefjgs123";
                });

            mockUnitOfWork.Setup(m => m.GetRepository<Assumption>())
             .Returns(mockAssumptionRep.Object);

            var assumptionService = new AssumptionsService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            var result = assumptionService.UpdateAssumption(new AssumptionRequest(), Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"));

            // Assert
            var assumptionResponse =
              new AssumptionResponse
              {
                  Id = "25a5ece8-8166-4a28-9252-00e6c619e423",
                  Description = "frkefjgs123",
                  ProjectId = "25a5ece8-8166-4a28-9252-00e6c619e4c0"
              };

            result.Should().BeEquivalentTo(assumptionResponse);
        }

        [Fact]
        public void DeleteAssumption()
        {
            var assumptions = new List<Assumption>()
                {
                     new Assumption
                    {
                        Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                        Description = "frkefjgs",
                        ProjectId = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e4c0")
                    }
                };

            var mockAssumptionRep = new Mock<IRepository<Assumption>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockAssumptionRep.Setup(m => m.Find(It.IsAny<Expression<Func<Assumption, bool>>>(), null))
                .Returns(assumptions);
            mockAssumptionRep.Setup(m => m.SoftDelete(It.IsAny<Guid>()))
                .Callback(() =>
                {
                    assumptions.First().IsDeleted = true;
                });

            mockUnitOfWork.Setup(m => m.GetRepository<Assumption>())
             .Returns(mockAssumptionRep.Object);

            var assumptionService = new AssumptionsService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            assumptionService.DeleteAssumption(Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"));

            // Assert
            var result = assumptions.First().IsDeleted;

            result.Should().BeTrue();
        }

    }
}