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
    public class ObjectiveServiceTests
    {
        [Fact]
        public void CreateObjective()
        {
            var objectives = new List<Objective>();
            var mockObjectiveRep = new Mock<IRepository<Objective>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockObjectiveRep.Setup(m => m.FindWithDeleted(It.IsAny<Expression<Func<Objective, bool>>>(), null))
                .Returns(objectives);
            mockObjectiveRep.Setup(m => m.Find(It.IsAny<Expression<Func<Objective, bool>>>(), null))
               .Returns(objectives);
            mockObjectiveRep.Setup(m => m.Create(It.IsAny<Objective>()))
                .Callback(() =>
                {
                    objectives.Add(new Objective
                    {
                        Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                        Title = "Title",
                        Description = "Description",
                        ProjectId = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e4c0")
                    });
                });

            mockUnitOfWork.Setup(m => m.GetRepository<Objective>())
             .Returns(mockObjectiveRep.Object);

            var assumptionService = new ObjectiveService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            var result = assumptionService.AddObjective(It.IsAny<ObjectiveRequest>());

            // Assert
            var objectiveResponse =
              new ObjectiveResponse
              {
                  Id = "25a5ece8-8166-4a28-9252-00e6c619e423",
                  Title = "Title",
                  Description = "Description",
                  ProjectId = "25a5ece8-8166-4a28-9252-00e6c619e4c0"
              };

            result.Should().BeEquivalentTo(objectiveResponse);
        }

        [Fact]
        public void UpdateObjective()
        {
            //Arrange
            var objectives = new List<Objective>()
            {
                new Objective
                {
                    Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                    Title = "Title",
                    Description = "Description",
                    ProjectId = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e4c0")
                }
            };
            var mockObjectiveRep = new Mock<IRepository<Objective>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockObjectiveRep.Setup(m => m.Find(It.IsAny<Expression<Func<Objective, bool>>>(), null))
               .Returns(objectives);
            mockObjectiveRep.Setup(m => m.Update(It.IsAny<Objective>()))
                .Callback(() =>
                {
                    objectives.First().Title = "Title123";
                });
            mockUnitOfWork.Setup(m => m.GetRepository<Objective>())
             .Returns(mockObjectiveRep.Object);

            var objectivesService = new ObjectiveService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            var result = objectivesService.UpdateObjective(new ObjectiveRequest(), new Guid("25a5ece8-8166-4a28-9252-00e6c619e423"));

            // Assert
            var objectiveResponse =
              new ObjectiveResponse
              {
                  Id = "25a5ece8-8166-4a28-9252-00e6c619e423",
                  Title = "Title123",
                  Description = "Description",
                  ProjectId = "25a5ece8-8166-4a28-9252-00e6c619e4c0"
              };

            result.Should().BeEquivalentTo(objectiveResponse);
        }

        [Fact]
        public void DeleteObjective()
        {
            var objectives = new List<Objective>()
            {
                new Objective
                {
                    Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                    Title = "Title",
                    Description = "Description",
                    ProjectId = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e4c0")
                }
            };
            var mockObjectiveRep = new Mock<IRepository<Objective>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockObjectiveRep.Setup(m => m.Find(It.IsAny<Expression<Func<Objective, bool>>>(), null))
               .Returns(objectives);
            mockObjectiveRep.Setup(m => m.SoftDelete(It.IsAny<Guid>()))
                .Callback(() =>
                {
                    objectives.First().IsDeleted = true;
                });

            mockUnitOfWork.Setup(m => m.GetRepository<Objective>())
             .Returns(mockObjectiveRep.Object);

            var objectivesService = new ObjectiveService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            objectivesService.DeleteObjective("25a5ece8-8166-4a28-9252-00e6c619e423");

            // Assert
            var result = objectives.First().IsDeleted;

            result.Should().BeTrue();
        }
    }
}
