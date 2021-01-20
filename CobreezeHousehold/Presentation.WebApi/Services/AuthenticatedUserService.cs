using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Presentation.WebApi.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        /*
         * TODO: uncomment
         */
        public int UserId { get; set; }

        //public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        //{
        //    UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
        //}

        public AuthenticatedUserService()
        {
            UserId = 2;
        }
    }
}
