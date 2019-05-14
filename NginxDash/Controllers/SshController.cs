using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NginxDash.Services;
using Renci.SshNet;

namespace NginxDash.Controllers
{
    [Route("_api/[controller]")]
    public class SshController : Controller
    {
        private readonly INginxCommands _nginxCommans;

        public SshController(INginxCommands nginxCommans)
        {
            _nginxCommans = nginxCommans;
        }

        [HttpGet("nginx/test")]
        public async Task<string> NginxTestAsync()
        {
            return await Task.FromResult(_nginxCommans.TestConf());
        }

        [HttpGet("nginx/reload")]
        public async Task<string> NginxReloadAsync()
        {
            return await Task.FromResult(_nginxCommans.ReloadConf());
        }

    }
}