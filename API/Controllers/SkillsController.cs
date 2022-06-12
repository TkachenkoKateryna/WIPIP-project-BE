﻿using API.Controllers.Base;
using Domain.Models.Dtos.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.Dtos.Request;
using Domain.Models.Dtos.Requests;

namespace API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        readonly ISkillsService _skillService;

        public SkillsController(ISkillsService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SkillResponse>> GetSkills()
        {
            return Ok(_skillService.GetSkills());
        }

        [HttpPost]
        public ActionResult<SkillResponse> AddSkill(SkillRequest skillRequest)
        {
            return Ok(_skillService.AddSkill(skillRequest));
        }

        [HttpPut("{skillId}")]
        public ActionResult<RiskResponse> UpdateSkill(SkillRequest skillRequest, Guid skillId)
        {
            return Ok(_skillService.UpdateSkill(skillRequest, skillId));
        }

        [HttpDelete("{skillId}")]
        public IActionResult DeleteSkill(Guid skillId)
        {
            _skillService.DeleteSkill(skillId);

            return Ok();
        }

    }
}
