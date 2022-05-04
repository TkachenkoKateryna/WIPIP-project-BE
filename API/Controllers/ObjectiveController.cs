using Application.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ObjectiveController : BaseApiController
    {
        readonly IObjectiveService _objService;

        public ObjectiveController(IObjectiveService objService)
        {
            _objService = objService;
        }

        [HttpGet("objectivesByProject/{projId}")]
        public ActionResult<IEnumerable<ObjectiveResponse>> GetAllObjectiveByProject(string projId)
        {
            return Ok(_objService.GetAllObjectivesByProject(projId));
        }

        [HttpGet("objectives")]
        public ActionResult<IEnumerable<ObjectiveResponse>> GetAllObjectives()
        {
            return Ok(_objService.GetAllObjectives());
        }

        [HttpPut("objectives/add")]
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

        [HttpPut("objectives/update/{objId}")]
        public ActionResult<ObjectiveResponse> UpdateProduct(ObjectiveRequest objRequest, string objId)
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

        [HttpDelete("objectives/delete/{objId}")]
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
