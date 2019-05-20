namespace NginxDashCore.Services
{
    public interface INginx
    {
        bool TestConfig();
        bool SetupDomains();
    }
}