using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private readonly string sshPath;

        private readonly string[] ignoreDirs = { ".", ".." };

        public NginxCommands(IConfiguration config)
        {
            var sshConfig = config.GetSection("SshConfig");
            sshPort = sshConfig.GetValue("port", 22);
            sshHost = sshConfig.GetValue("host", "wayproyect_nginx");
            sshUser = sshConfig.GetValue("user", "root");
            sshPswd = sshConfig.GetValue("pswd", "root");
            sshPath = sshConfig.GetValue("path", "/etc/nginx/conf.d");
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

        private List<string> ListConfigFiles(SftpClient sftp, string sftpPath)
        {

            List<string> filesList = new List<string>();
            var directory = sftp.ListDirectory(sftpPath);

            foreach (var path in directory)
            {
                if (ignoreDirs.Contains(path.Name)) continue;
                if (path.IsDirectory)
                {
                    var fileInDir = ListConfigFiles(sftp, $"{sftpPath}/{path.Name}");
                    foreach (var pathDir in fileInDir)
                    {
                        filesList.Add($"{path.Name}/{pathDir}");
                    }
                }

                if (Regex.Match(path.Name, @".*\.conf", RegexOptions.IgnoreCase).Success)
                {
                    filesList.Add(path.Name);
                }
            }
            return filesList;
        }

        public List<string> ConfigFiles()
        {
            List<string> filesList = new List<string>();
            using (SftpClient sftp = new SftpClient(sshHost, sshPort, sshUser, sshPswd))
            {
                try
                {
                    sftp.Connect();
                    filesList = ListConfigFiles(sftp, sshPath);
                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }

            return filesList;
        }

        public string NewConfigFile()
        {
            using (SftpClient sftp = new SftpClient(sshHost, sshPort, sshUser, sshPswd))
            {
                try
                {
                    sftp.Connect();

                    var newConf = sftp.Create(sshPath + "/wayprotect.com/blog.conf");
                    newConf.Write(Encoding.UTF8.GetBytes("# hola mundo -"));
                    newConf.Close();

                    sftp.Disconnect();
                    return $"new file created {sshPath}/new.conf";
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                    return e.Message;
                }
            }
        }

        public string ReadConfigFile(string path)
        {
            using (SftpClient sftp = new SftpClient(sshHost, sshPort, sshUser, sshPswd))
            {
                try
                {
                    sftp.Connect();
                    var fileText = sftp.ReadAllText($"{sshPath}/{path}");
                    sftp.Disconnect();
                    return fileText;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                    return e.Message;
                }
            }
        }
    }
}