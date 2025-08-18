using Dto.Auth;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.JWTAuthenticationManager
{
    public interface IJWTAuthenticationManager
    {
         Task<AuthenticationResponse> Authenticate(string userName, string deviceSerialNumber, Claim[] claims,string appName=null, string platform = null);

         Task<APIResponse<AuthenticationResponse>> RefreshTokenAsync(RefreshTokenDto refreshToken);
    }
}
 