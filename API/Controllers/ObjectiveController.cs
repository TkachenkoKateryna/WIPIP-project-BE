using API.Controllers.Base;
using Application.Interfaces;
using Application.Interfaces.Util;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ObjectiveController : BaseApiController
    {
        readonly IObjectiveService _objService;

        public ObjectiveController(
            IObjectiveService objService)
        {
            _objService = objService;
        }

        [HttpGet("objectives")]
        public ActionResult<IEnumerable<ObjectiveResponse>> GetAllObjectives()
        {
            return Ok(_objService.GetAllObjectives());
        }

        [HttpPost("objectives")]
        public ActionResult<ObjectiveResponse> AddObjective(ObjectiveRequest objRequest)
        {
            try
            {
                var objResp = _objService.AddObjective(objRequest);
                return Ok(objResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("objectives/{objId}")]
        public ActionResult<ObjectiveResponse> UpdateObjective(ObjectiveRequest objRequest, string objId)
        {
            try
            {
                var objResp = _objService.UpdateObjective(objRequest, objId);
                return Ok(objResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("objectives/{objId}")]
        public IActionResult DeleteObjective(string objId)
        {
            try
            {
                _objService.DeleteObjective(objId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
