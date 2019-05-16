using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NginxDash.Models;
using NginxDash.Services;

namespace NginxDash.Controllers
{
    [Route("_api/[controller]")]
    public class NginxController : Controller
    {
        private readonly INginxCommands _nginxCommans;

        public NginxController(INginxCommands nginxCommans)
        {
            _nginxCommans = nginxCommans;
        }

        [HttpGet("test")]
        public async Task<string> TestAsync()
        {
            return await Task.FromResult(_nginxCommans.TestConf());
        }

        [HttpGet("reload")]
        public async Task<string> ReloadAsync()
        {
            return await Task.FromResult(_nginxCommans.ReloadConf());
        }

        [HttpGet("config/all")]
        public async Task<ApiResponse<List<string>>> ConfigListAllAsync()
        {
            return await Task.FromResult(new ApiResponse<List<string>>
            {
                Payload = _nginxCommans.ConfigFiles()
            });
        }

        [HttpGet("config/{*path}")]
        public async Task<ApiResponse<string>> NginxNewConfigAsync(string path)
        {
            return await Task.FromResult(new ApiResponse<string>
            {
                Payload = _nginxCommans.ReadConfigFile(path)
            });
        }
    }
}