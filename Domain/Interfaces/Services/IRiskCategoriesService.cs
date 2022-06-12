using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IRiskCategoriesService
    {
        IEnumerable<RiskCategoryResponse> GetRiskCategories();
        RiskCategoryResponse AddRiskCategory(RiskCategoryRequest riskCategoryRequest);
        RiskCategoryResponse UpdateRiskCategory(RiskCategoryRequest skillRequest, Guid riskCategoryId);
        void DeleteRiskCategory(Guid riskCategoryId);
    }
}
