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
    public class RiskCategoriesServiceTests
    {
        [Fact]
        public void GetRiskCategories()
        {

            // Arrange
            var riskCategories = new List<RiskCategory>()
            {
                new RiskCategory
                {
                    Id = Guid.Parse("e675867e-f6b0-4478-8799-9abd6317db16"),
                    Title = "Design Risks"
                }
            };
            var mockRiskCategoryRep = new Mock<IRepository<RiskCategory>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRiskCategoryRep.Setup(m => m.GetAll(null))
                .Returns(riskCategories);

            mockUnitOfWork.Setup(m => m.GetRepository<RiskCategory>())
             .Returns(mockRiskCategoryRep.Object);

            var service = new RiskCategoriesService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            var result = service.GetRiskCategories();

            var response = new List<RiskCategoryResponse>()
            {
                new RiskCategoryResponse
                {
                    Id = "e675867e-f6b0-4478-8799-9abd6317db16",
                    Title = "Design Risks"
                }
            };

            // Assert
            result.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void CreateRiskCategory()
        {
            var riskCategories = new List<RiskCategory>();
            var mockRiskCategoryRep = new Mock<IRepository<RiskCategory>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRiskCategoryRep.Setup(m => m.Find(It.IsAny<Expression<Func<RiskCategory, bool>>>(), null))
                .Returns(riskCategories);
            mockRiskCategoryRep.Setup(m => m.CreateWithVal(It.IsAny<RiskCategory>()))
                .Callback(() =>
                {
                    riskCategories.Add(new RiskCategory
                    {
                        Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                        Title = "Test Category"
                    });
                });

            mockUnitOfWork.Setup(m => m.GetRepository<RiskCategory>())
             .Returns(mockRiskCategoryRep.Object);

            var service = new RiskCategoriesService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            var result = service.AddRiskCategory(new RiskCategoryRequest());

            // Assert
            var response =
              new RiskCategoryResponse
              {
                  Id = "25a5ece8-8166-4a28-9252-00e6c619e423",
                  Title = "Test Category"
              };

            result.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void UpdateRiskCategory()
        {

            var riskCategories = new List<RiskCategory>()
                {
                     new RiskCategory
                    {
                        Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                        Title = "Test Category"
                    }
                };

            var mockRiskCategoryRep = new Mock<IRepository<RiskCategory>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRiskCategoryRep.Setup(m => m.Find(It.IsAny<Expression<Func<RiskCategory, bool>>>(), null))
                .Returns(riskCategories);
            mockRiskCategoryRep.Setup(m => m.Update(It.IsAny<RiskCategory>()))
                .Callback(() =>
                {
                    riskCategories.First().Title = "Test Category Updated";
                });

            mockUnitOfWork.Setup(m => m.GetRepository<RiskCategory>())
             .Returns(mockRiskCategoryRep.Object);

            var service = new RiskCategoriesService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            var result = service.UpdateRiskCategory(new RiskCategoryRequest(), Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"));

            // Assert
            var response =
              new RiskCategoryResponse
              {
                  Id = "25a5ece8-8166-4a28-9252-00e6c619e423",
                  Title = "Test Category Updated"
              };

            result.Should().BeEquivalentTo(response);
        }

        [Fact]
        public void DeleteSkill()
        {
            var riskCategories = new List<RiskCategory>()
                {
                     new RiskCategory
                    {
                        Id = Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"),
                        Title = "Test Assumption"
                    }
                };

            var mockRiskCategoryRep = new Mock<IRepository<RiskCategory>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockRiskCategoryRep.Setup(m => m.Find(It.IsAny<Expression<Func<RiskCategory, bool>>>(), null))
                .Returns(riskCategories);
            mockRiskCategoryRep.Setup(m => m.SoftDelete(It.IsAny<Guid>()))
                .Callback(() =>
                {
                    riskCategories.First().IsDeleted = true;
                });

            mockUnitOfWork.Setup(m => m.GetRepository<RiskCategory>())
             .Returns(mockRiskCategoryRep.Object);

            var service = new RiskCategoriesService(mockUnitOfWork.Object, MapperFactory.GetMapper());

            // Act
            service.DeleteRiskCategory(Guid.Parse("25a5ece8-8166-4a28-9252-00e6c619e423"));

            // Assert
            var result = riskCategories.First().IsDeleted;

            result.Should().BeTrue();
        }


    }
}
