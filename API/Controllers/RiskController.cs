using System.Diagnostics;
using System.Drawing.Text;
using API.Controllers.Base;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Domain.Models.Dtos.Request;
using Domain.Models.Constants;

namespace API.Controllers
{
    public class RiskController : BaseApiController
    {
        private readonly IRiskService _riskService;
        private readonly IExcelService _excelService;

        public RiskController(
            IRiskService riskService,
            IExcelService excelService)
        {
            _riskService = riskService;
            _excelService = excelService;
        }

        [HttpGet("risks")]
        public ActionResult<IEnumerable<RiskResponse>> GetAllRisks()
        {
            return Ok(_riskService.GetAllRisks());
        }

        [HttpGet("generateRisks")]
        public ActionResult<IEnumerable<RiskResponse>> GenerateRisks([FromQuery] string projectId)
        {
            return Ok(_riskService.GenerateRisks(projectId));
        }

        [AllowAnonymous]
        [HttpGet("riskCategories")]
        public ActionResult<IEnumerable<RiskCategoryResponse>> GetAllRiskCategories()
        {
            return Ok(_riskService.GetRiskCategories());
        }

        [HttpPost("risks")]
        public ActionResult<RiskResponse> AddObjective(RiskRequest riskRequest)
        {
            try
            {
                var riskResp = _riskService.AddRisk(riskRequest);
                return Ok(riskResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("risks/{riskId}")]
        public ActionResult<RiskResponse> UpdateRisk(RiskRequest riskRequest, string riskId)
        {
            try
            {
                var riskResp = _riskService.UpdateRisk(riskRequest, riskId);
                return Ok(riskResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("risks/{riskId}")]
        public IActionResult DeleteRisk(string riskId)
        {
            try
            {
                _riskService.DeleteRisk(riskId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("projects/{projectId}/risks/{riskId}")]
        public ActionResult<RiskResponse> RemoveRiskFromProject(string projectId, string riskId)
        {
            try
            {
                var risk = _riskService.RemoveRiskFromProject(projectId, riskId);
                return Ok(risk);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("projects/{projectId}/risks/{riskId}")]
        public ActionResult<RiskResponse> AssignRiskToProject(string projectId, string riskId)
        {
            var risk = _riskService.AssignRiskToProject(projectId, riskId);

            return Ok(risk);
        }

        [HttpGet("risks/dowbloadExcel")]
        public FileResult Excel([FromQuery] string projectId)
        {
            return File(
                _excelService.GenerateRiskRegisterXml(projectId),
                "application/xml",
                "risks.xlsx");
        }
    }
}
