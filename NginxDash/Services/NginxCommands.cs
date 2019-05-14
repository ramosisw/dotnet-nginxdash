using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Renci.SshNet;

namespace NginxDash.Services
{
    public class NginxCommands : INginxCommands
    {
        private readonly int sshPort;
        private readonly string sshHost;
        private readonly string sshUser;
        private readonly string sshPswd;

        public NginxCommands(IConfiguration config)
        {
            var sshConfig = config.GetSection("SshConfig");
            sshPort = sshConfig.GetValue("port", 22);
            sshHost = sshConfig.GetValue("host", "wayproyect_nginx");
            sshUser = sshConfig.GetValue("user", "root");
            sshPswd = sshConfig.GetValue("pswd", "root");
        }


        private string ExecuteCommand(string cmd)
        {
            try
            {
                using (var client = new SshClient(sshHost, sshPort, sshUser, sshPswd))
                {
                    client.Connect();

                    var command = client.CreateCommand(cmd);
                    var result = command.Execute();

                    var reader = new StreamReader(command.ExtendedOutputStream);
                    var strOutput = reader.ReadToEnd();

                    client.Disconnect();
                    return strOutput;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ReloadConf()
        {
            return ExecuteCommand("nginx -s reload");
        }

        public string TestConf()
        {
            return ExecuteCommand("nginx -t");
        }
    }
}