using NginxDashCore.Data.Entities;

namespace NginxDashCommon.Services
{
    public interface INginxConfGenerator
    {
        string GenerateDomain(string domain);
        string GenerateSubdomain(string domain, Subdomain subdomain);
        string GenerateLocation(Location location);
    }
}