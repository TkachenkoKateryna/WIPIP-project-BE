﻿using API.Controllers.Base;
using Application.Interfaces;
using Application.Interfaces.Util;
using Domain.Dtos.Requests;
using Domain.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MilestonesController : BaseApiController
    {
        readonly IMilestoneService _milService;

        public MilestonesController(
            IMilestoneService milService)
        {
            _milService = milService;
        }

        [HttpGet("milestones")]
        public ActionResult<IEnumerable<MilestoneResponse>> GetAllMilestones()
        {
            return Ok(_milService.GetAllMilestones());
        }

        [HttpPost("milestones")]
        public ActionResult<MilestoneResponse> AddMilestone(MilestoneRequest milRequest)
        {
            try
            {
                var milResp = _milService.AddMilestone(milRequest);
                return Ok(milResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("milestones/{milId}")]
        public ActionResult<MilestoneResponse> UpdateMilestone(MilestoneRequest milRequest, string milId)
        {
            try
            {
                var milResp = _milService.UpdateMilestone(milRequest, milId);
                return Ok(milResp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("milestones/{milId}")]
        public IActionResult DeleteMilestone(string milId)
        {
            try
            {
                _milService.DeleteMilestone(milId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
