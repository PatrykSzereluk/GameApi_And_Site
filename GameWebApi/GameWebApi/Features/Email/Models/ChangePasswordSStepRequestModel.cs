﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebApi.Features.Email.Models
{
    public class ChangePasswordSStepRequestModel : ChangeUserParamRequestModel
    {
        public string Password { get; set; }
    }
}
