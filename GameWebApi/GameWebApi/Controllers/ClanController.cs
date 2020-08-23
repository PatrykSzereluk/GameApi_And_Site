﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameWebApi.Features.Clan.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameWebApi.Controllers
{
    public class ClanController : ApiController
    {
        private readonly IClanService _clanService;

        public ClanController(IClanService clanService)
        {
            this._clanService = clanService;
        }

        [Route(nameof(AddNewClan))]
        public async Task<NewClanResponseModel> AddNewClan(NewClanRequestModel model)
        {
            return await _clanService.AddNewClan(model);
        }

    }
}