using Application.Interfaces;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RiskController : BaseApiController
    {
        readonly IRiskService _riskService;

        public RiskController(IRiskService riskService)
        {
            _riskService = riskService;
        }

        [HttpGet("risksByProject/{projId}")]
        public ActionResult<IEnumerable<RiskResponse>> GetAllRiskByProject(string projId)
        {
            return Ok(_riskService.GetAllRisksByProject(projId));
        }

        [HttpGet("risks")]
        public ActionResult<IEnumerable<RiskResponse>> GetAllRisks()
        {
            return Ok(_riskService.GetAllRisks());
        }

        [HttpPut("risks/add")]
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

        [HttpPut("risks/update/{objId}")]
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

        [HttpDelete("risks/delete/{riskId}")]
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
    }
}
