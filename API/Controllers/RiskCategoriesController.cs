using Domain.Interfaces.Services;
using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/riskCategories")]
    public class RiskCategoriesController : ControllerBase
    {
        readonly IRiskCategoriesService _riskCategoryService;

        public RiskCategoriesController(IRiskCategoriesService riskCategoryService)
        {
            _riskCategoryService = riskCategoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RiskCategoryResponse>> GetRiskCategories()
        {
            return Ok(_riskCategoryService.GetRiskCategories());
        }

        [HttpPost]
        public ActionResult<SkillResponse> AddRiskCategories(RiskCategoryRequest riskCategoryRequest)
        {
            return Ok(_riskCategoryService.AddRiskCategory(riskCategoryRequest));
        }

        [HttpPut("{riskCategoryId:Guid}")]
        public ActionResult<RiskResponse> UpdateRiskCategories(RiskCategoryRequest riskCategoryRequest, Guid riskCategoryId)
        {
            return Ok(_riskCategoryService.UpdateRiskCategory(riskCategoryRequest, riskCategoryId));
        }

        [HttpDelete("{riskCategoryId:Guid}")]
        public IActionResult DeleteRiskCategories(Guid riskCategoryId)
        {
            _riskCategoryService.DeleteRiskCategory(riskCategoryId);

            return Ok();
        }

    }
}
