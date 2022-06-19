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

        [HttpPost]
        public ActionResult<ObjectiveResponse> AddObjective(ObjectiveRequest objRequest)
        {
            return Ok(_objService.AddObjective(objRequest));
        }

        [HttpPut("{objectiveId:Guid}")]
        public ActionResult<ObjectiveResponse> UpdateObjective(ObjectiveRequest objRequest, Guid objectiveId)
        {
            return Ok(_objService.UpdateObjective(objRequest, objectiveId));
        }

        [HttpDelete("{objectiveId:Guid}")]
        public IActionResult DeleteObjective(Guid objectiveId)
        {
            _objService.DeleteObjective(objectiveId);

            return Ok();
        }
    }
}
