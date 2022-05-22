﻿using Domain.Dtos.Requests;
using Domain.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IMilestoneService
    {
        IEnumerable<MilestoneResponse> GetAllMilestones();
        MilestoneResponse AddMilestone(MilestoneRequest milRequest);
        MilestoneResponse UpdateMilestone(MilestoneRequest milRequest, string milId);
        void DeleteMilestone(string milId);
    }
}