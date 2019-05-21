using NginxDashCommon.Models.Subdomain;
using NginxDashCommon.Models.Domain;
using System.Threading.Tasks;
using System;

namespace NginxDashCommon.Services
{
    public interface INginx
    {
        bool TestConfig();
        Task<bool> SetupDomainAsync(DomainModel domain);
        Task<bool> SetupSubdomainAsync(Guid domainId, SubdomainModel domain);
    }
}