using System;
using System.Threading.Tasks;
using NginxDashCommon.Models.Domain;
using NginxDashCommon.Models.Subdomain;

namespace NginxDashCommon.Services
{
    public interface INginx
    {
        bool TestConfig();
        Task<bool> SetupDomainAsync(DomainModel domain);
        Task<bool> SetupSubdomainAsync(Guid domainId, SubdomainModel domain);
    }
}