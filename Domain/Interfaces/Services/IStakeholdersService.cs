﻿using Domain.Dtos.Requests;
using Domain.Dtos.Responses;

namespace Domain.Interfaces.Services
{
    public interface IStakeholdersService
    {
        IEnumerable<StakeholderResponse> GetAllStakeholders();
        StakeholderResponse AddStakeholder(StakeholderRequest stRequest);
        StakeholderResponse UpdateStakeholder(StakeholderRequest stRequest, string stId);
        void DeleteStakeholder(StakeholderDeleteRequest stRequest);

    }
}