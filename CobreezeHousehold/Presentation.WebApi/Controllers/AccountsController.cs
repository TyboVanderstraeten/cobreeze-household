using Application.DTOs.Account;
using Application.Interfaces;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Authenticates a User.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Authenticate")]
        public async Task<ActionResult<Response<AuthenticationResponse>>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request, GenerateIPAddress()));
        }

        /// <summary>
        /// Registers a New User.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<ActionResult<Response<string>>> RegisterAsync(RegisterRequest request)
        {
            StringValues origin = Request.Headers["origin"];

            return Ok(await _accountService.RegisterAsync(request, origin));
        }

        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }
    }
}
