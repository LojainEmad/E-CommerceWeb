using Abstraction;
using Microsoft.AspNetCore.Mvc;
using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthenticationController(IServicesManager servicesManager) :ApiBaseController
    {
        //Login
        [HttpPost("Login")]  //post baseUrl/api/Authentication/Login
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var User = await servicesManager.AuthenticationServices.LoginAsync(loginDto);
            return Ok(User);
        }


        //Register
        [HttpPost("Register")]  //post baseUrl/api/Authentication/Register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var User = await servicesManager.AuthenticationServices.RegisterAsync(registerDto);
            return Ok(User);
        }

    }
}
