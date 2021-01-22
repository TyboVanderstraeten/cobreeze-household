using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace Presentation.WebApi.Controllers
{
    [AllowAnonymous]
    public class InfoController : BaseApiController
    {
        /// <summary>
        /// Gets Api Meta Info.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/info")]
        public async Task<ActionResult<string>> Info()
        {
            Assembly assembly = typeof(Startup).Assembly;
            DateTime lastUpdate = System.IO.File.GetLastWriteTime(assembly.Location);
            string version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {lastUpdate}.");
        }
    }
}

