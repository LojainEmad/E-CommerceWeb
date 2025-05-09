using Abstraction;
using Domain.Exceptions;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Shared.Dto_s.IdentityDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthenticationServices(UserManager<ApplicationUser> userManager) : IAuthenticationServices
    {
        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
           //Check if Email is Exist
           var User = await userManager.FindByEmailAsync(loginDto.Email);
            if(User is  null) throw new UserNotFoundException(loginDto.Email);

            //Check Password

            var IsPasswordValid = await userManager.CheckPasswordAsync(User, loginDto.Password);
            if (IsPasswordValid)
            {
                return new UserDto()
                {
                    DisplayName = User.DisplayName,
                    Email = loginDto.Email,
                    Token = CreateTokenAsync(User)
                };
            }
            else
            {
                throw new UnAuthorizedException();
            }

        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            //Mapping From RegisterDto => ApplicationUser
            var User = new ApplicationUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.UserName,
            };

            //Create User
            var Result = await userManager.CreateAsync(User, registerDto.Password);
            if (Result.Succeeded)
                return new UserDto()
                {
                    DisplayName = registerDto.DisplayName,
                    Email = registerDto.Email,
                    Token = CreateTokenAsync(User)
                };

            else
            {
                var Errors = Result.Errors.Select(E=>E.Description).ToList();
                throw new BadRequestException(Errors);
            }
        }

        public static string CreateTokenAsync(ApplicationUser user)
        {
            return "Token - TODO";
        }
    }
}
