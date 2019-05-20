using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NginxDash.Models;
using NginxDashCommon.Models.Domain;
using NginxDashCommon.Services;

namespace NginxDash.Controllers
{
    [Produces("application/json")]
    [Route("_api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        private readonly INginx _nginx;

        public DomainController(INginx nginx)
        {
            _nginx = nginx;
        }

        [HttpPost]
        public async Task<ApiResponse> PostAsync(DomainModel domain)
        {
            return new ApiResponse
            {
                HasError = await _nginx.SetupDomainAsync(domain)
            };
        }
    }
}