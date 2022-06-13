using API.Controllers.Base;
using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/objectives")]
    public class ObjectiveController : ControllerBase
    {
        readonly IObjectiveService _objService;

        public ObjectiveController(IObjectiveService objService)
        {
            _objService = objService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ObjectiveResponse>> GetAllObjectives()
        {
            return Ok(_objService.GetAllObjectives());
        }

        [HttpPost]
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

        [HttpPut("{objectiveId:Guid}")]
        public ActionResult<ObjectiveResponse> UpdateObjective(ObjectiveRequest objRequest, Guid objectiveId)
        {
            try
            {
                var objResp = _objService.UpdateObjective(objRequest, objectiveId);
                return Ok(objResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{objectiveId}")]
        public IActionResult DeleteObjective(string objectiveId)
        {
            try
            {
                _objService.DeleteObjective(objectiveId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
