using System.Collections.Generic;

namespace NginxDash.Services
{
    public interface INginxCommands
    {
        string ReloadConf();
        string TestConf();
        string NewConfigFile();
        string ReadConfigFile(string path);
        List<string> ConfigFiles();
    }
}