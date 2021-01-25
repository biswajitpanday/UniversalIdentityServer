using System;
using System.Linq;
using System.Threading.Tasks;
using Identity.Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Service.Services
{
    public class UserRegisterService: ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRegisterService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //public override async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest request)
        public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new UserRegisterResponse
                {
                    IsCreated = false,
                    Message = $"{request.UserName} is already exist"
                };
            }

            var applicationUser = new ApplicationUser {UserName = request.UserName, ProfileId = Guid.Parse(request.ProfileId)};
            var result = await _userManager.CreateAsync(applicationUser, request.Pin);
            if (!result.Succeeded)
            {
                return new UserRegisterResponse
                {
                    IsCreated = false,
                    Message = String.Join(",", result.Errors.Select(x => x.Description))
                };
            }

            var roleResult = await _userManager.AddToRoleAsync(applicationUser, request.Role);
            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(applicationUser);
                return new UserRegisterResponse
                {
                    IsCreated = false,
                    Message = String.Join(",", roleResult.Errors.Select(x => x.Description))
                };
            }

            return new UserRegisterResponse
            {
                Message = $"{request.UserName} is created",
                IsCreated = true
            };
        }
    }
}