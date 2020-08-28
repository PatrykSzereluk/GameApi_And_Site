﻿namespace GameWebApi.Controllers
{
    using System.Threading.Tasks;
    using GameWebApi.Features.Clan.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ClanController : ApiController
    {
        private readonly IClanService _clanService;

        public ClanController(IClanService clanService)
        {
            this._clanService = clanService;
        }

        [HttpPost]
        [Route(nameof(AddNewClan))]
        public async Task<NewClanResponseModel> AddNewClan(NewClanRequestModel model)
        {
            return await _clanService.AddNewClan(model);
        }

        [HttpPost]
        [Route(nameof(AddMemberToClan))]
        public async Task<NewMemberToClanResponseModel> AddMemberToClan(NewMemberToClanRequestModel model)
        {
            return await _clanService.AddMemberToClan(model);
        }

        [HttpPut]
        [Route(nameof(ModifyMemberFunction))]
        public async Task<bool> ModifyMemberFunction(ModifyMemberRequestModel model)
        {
            return await _clanService.ModifyMemberFunction(model);
        }

        [HttpDelete]
        [Route(nameof(RemoveMember))]
        public async Task<bool> RemoveMember(RemoveUserRequestModel model)
        {
            return await _clanService.RemoveMember(model);  
        }

        [HttpDelete]
        [Route(nameof(RemoveClan))]
        public async Task<bool> RemoveClan(RemoveClanRequestModel model)
        {
            return await _clanService.RemoveClan(model);
        }
    }
}
