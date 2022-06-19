using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/risks")]
    public class RiskController : ControllerBase
    {
        private readonly IRiskService _riskService;
        private readonly IExcelService _excelService;

        public RiskController(IRiskService riskService, IExcelService excelService)
        {
            _riskService = riskService;
            _excelService = excelService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RiskResponse>> GetRisks()
        {
            return Ok(_riskService.GetRisks());
        }

        [HttpGet("generate")]
        public ActionResult<IEnumerable<RiskResponse>> GenerateRisks([FromQuery] Guid projectId)
        {
            return Ok(_riskService.GenerateRisks(projectId));
        }

        [HttpGet("file")]
        public FileResult Excel([FromQuery] Guid projectId)
        {
            return File(
                _excelService.GenerateRiskRegisterXml(projectId),
                "application/xml",
                "risks.xlsx");
        }

        [HttpPost]
        public ActionResult<RiskResponse> AddRisk(RiskRequest riskRequest)
        {
            return Ok(_riskService.AddRisk(riskRequest));
        }

        [HttpPut("{riskId:Guid}")]
        public ActionResult<RiskResponse> UpdateRisk(RiskRequest riskRequest, Guid riskId)
        {
            return Ok(_riskService.UpdateRisk(riskRequest, riskId));
        }

        [HttpPut("{riskId:Guid}/projects/{projectId:Guid}")]
        public ActionResult<RiskResponse> AssignRiskToProject(Guid projectId, Guid riskId)
        {
            return Ok(_riskService.AssignRiskToProject(projectId, riskId));
        }

        [HttpDelete("{riskId:Guid}")]
        public IActionResult DeleteRisk(Guid riskId)
        {
            _riskService.DeleteRisk(riskId);

            return Ok();
        }

        [HttpDelete("{riskId:Guid}/projects/{projectId:Guid}")]
        public ActionResult<RiskResponse> RemoveRiskFromProject(Guid projectId, Guid riskId)
        {
            return Ok(_riskService.RemoveRiskFromProject(projectId, riskId));
        }
    }
}
