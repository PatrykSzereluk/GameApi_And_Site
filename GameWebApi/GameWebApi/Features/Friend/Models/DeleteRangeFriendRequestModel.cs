﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Features.Friend.Models
{
    public class DeleteRangeFriendRequestModel: BaseRequestData
    {
        public IEnumerable<int> FriendIds { get; set; }
    }
}
