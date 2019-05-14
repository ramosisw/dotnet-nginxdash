namespace NginxDash.Services
{
    public interface INginxCommands
    {
        string ReloadConf();
        string TestConf();
    }
}