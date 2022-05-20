using API.Controllers.Base;
using Application.Interfaces;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SkillsController : BaseApiController
    {
        readonly ISkillsService _skillService;

        public SkillsController(
            ISkillsService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("skills")]
        public ActionResult<IEnumerable<SkillResponse>> GetAllAssumptions()
        {
            return Ok(_skillService.GetSkills());
        }

    }
}
