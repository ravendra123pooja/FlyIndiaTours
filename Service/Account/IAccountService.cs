﻿using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
namespace Service.Account
{
    public interface IAccountService
    {
        Task<APIResponse<UserDto>> Login(LoginModel loginModel);
    }
}
