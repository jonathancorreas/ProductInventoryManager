using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProductInventoryManager.Application.Contracts.Identity;
using ProductInventoryManager.Identity.Models;
using System.Security.Claims;

namespace ProductInventoryManager.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }
    }
}