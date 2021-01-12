using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Presentation.WebApi.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public string UserId { get; set; }

        //public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        //{
        //    UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
        //}

        public AuthenticatedUserService()
        {
            UserId = "TyboTestUID";
        }
    }
}
