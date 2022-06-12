
using Domain.Interfaces.Repositories;
using Domain.Models.Dtos.Request;
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
    public class SkillServiceTests
    {
        [Fact]
        public void GetSkills()
        {
            var skills = new List<Skill>()
            {
                new Skill
                {
                    Id = Guid.Parse("e675867e-f6b0-4478-8799-9abd6317db16"),
                    Title = "Design"
                }
            };
            var mockSkillsRep = new Mock<IRepository<Skill>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockSkillsRep.Setup(m => m.GetAll(null))
                .Returns(skills);

            mockUnitOfWork.Setup(m => m.GetRepository<Skill>())
             .Returns(mockSkillsRep.Object);

            var skillsService = new SkillsService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            var result = skillsService.GetSkills();

            var skillsResponse = new List<SkillResponse>()
            {
                new SkillResponse
                {
                    Id = "e675867e-f6b0-4478-8799-9abd6317db16",
                    Title = "Design"
                }
            };
            // Assert

            result.Should().BeEquivalentTo(skillsResponse);
        }

        [Fact]
        public void CreateSkill()
        {
            var skills = new List<Skill>();
            var mockSkillRep = new Mock<IRepository<Skill>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockSkillRep.Setup(m => m.Find(It.IsAny<Expression<Func<Skill, bool>>>(), null))
                .Returns(skills);
            mockSkillRep.Setup(m => m.CreateWithVal(It.IsAny<Skill>()))
                .Callback(() =>
                {
                    skills.Add(new Skill
                    {
                        Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                        Title = "Test Assumption"
                    });
                });

            mockUnitOfWork.Setup(m => m.GetRepository<Skill>())
             .Returns(mockSkillRep.Object);

            var service = new SkillsService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            var result = service.AddSkill(new SkillRequest());

            // Assert
            var response =
              new SkillResponse
              {
                  Id = "25a5ece8-8166-4a28-9252-00e6c619e423",
                  Title = "Test Assumption"
              };

            result.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void UpdateSkill()
        {

            var skills = new List<Skill>()
                {
                     new Skill
                    {
                        Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                        Title = "Test Assumption"
                    }
                };

            var mockSkillRep = new Mock<IRepository<Skill>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockSkillRep.Setup(m => m.Find(It.IsAny<Expression<Func<Skill, bool>>>(), null))
                .Returns(skills);
            mockSkillRep.Setup(m => m.Update(It.IsAny<Skill>()))
                .Callback(() =>
                {
                    skills.First().Title = "Test Assumption Updated";
                });

            mockUnitOfWork.Setup(m => m.GetRepository<Skill>())
             .Returns(mockSkillRep.Object);

            var service = new SkillsService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            var result = service.UpdateSkill(new SkillRequest(), Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"));

            // Assert
            var response =
              new SkillResponse
              {
                  Id = "25a5ece8-8166-4a28-9252-00e6c619e423",
                  Title = "Test Assumption Updated"
              };

            result.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void DeleteSkill()
        {
            var skills = new List<Skill>()
                {
                     new Skill
                    {
                        Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                        Title = "Test Assumption"
                    }
                };

            var mockSkillRep = new Mock<IRepository<Skill>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockSkillRep.Setup(m => m.Find(It.IsAny<Expression<Func<Skill, bool>>>(), null))
                .Returns(skills);
            mockSkillRep.Setup(m => m.SoftDelete(It.IsAny<Guid>()))
                .Callback(() =>
                {
                    skills.First().IsDeleted = true;
                });

            mockUnitOfWork.Setup(m => m.GetRepository<Skill>())
             .Returns(mockSkillRep.Object);

            var service = new SkillsService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            service.DeleteSkill(Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"));

            // Assert
            var result = skills.First().IsDeleted;

            result.Should().BeTrue();
        }
    }
}
