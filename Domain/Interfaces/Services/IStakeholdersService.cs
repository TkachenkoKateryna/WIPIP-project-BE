﻿using Domain.Models.Dtos.Requests;
using Domain.Models.Dtos.Responses;
using Domain.Models.Dtos.Stakeholder;

namespace Domain.Interfaces.Services
{
    public interface IStakeholdersService
    {
        IEnumerable<StakeholderResponse> GetStakeholders();
        IEnumerable<StakeholderResponse> GetStakeholders(string projectId);
        StakeholderResponse AddStakeholder(StakeholderRequest stRequest);
        StakeholderResponse UpdateStakeholder(StakeholderRequest stRequest, string stId);
        void DeleteStakeholder(string stakeholderId);

        StakeholderResponse AddStakeholderToProject(string projectId, string stakeholderId);
        StakeholderResponse RemoveStakeholderFromProject(string projectId, string stakeholderId);
    }
}
