﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Features.Clan.Models
{
    public interface IClanService
    {
         Task<NewClanResponseModel> AddNewClan(NewClanRequestModel model);
         Task<NewMemberToClanResponseModel> AddMemberToClan(NewMemberToClanRequestModel model);
    }
}
