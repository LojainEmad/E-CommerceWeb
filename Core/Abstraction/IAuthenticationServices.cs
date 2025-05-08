using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IAuthenticationServices
    {

        //Login
        //Take Email Password || Token ,Email ,DisplayName
        Task<UserDto> LoginAsync(LoginDto loginDto);


        //Register
        //Take DisplayName UserName PhoneNumber Email Password || Token ,Email ,DisplayName

        Task<UserDto> RegisterAsync(RegisterDto registerDto);

    }
}
