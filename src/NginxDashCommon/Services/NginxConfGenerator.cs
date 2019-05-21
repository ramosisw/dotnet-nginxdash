using NginxDashCore.Data.Entities;
using System.Collections.Generic;
using NginxDashCore.Extensions;
using NginxDashCore.Enum;
using System.Linq;

namespace NginxDashCommon.Services
{
    public class NginxConfGenerator : INginxConfGenerator
    {
        public string GenerateDomain(string domain)
        {
            return $"include {domain}/*.conf\r";
        }

        public string GenerateSubdomain(string domain, Subdomain subdomain)
        {
            var lines = new List<string>();
            lines.Add("server {");
            lines.Add($"\tlisten {80};");
            lines.Add($"\tserver_name {subdomain.Name}.{domain}" + (subdomain.IsDomainRoot ? $" {domain}" : ""));
            //lines.Add($"\taccess_log logs/{subdomain.Name}.{domain}.log main");
            lines.Add($"\troot /var/www/{domain}/{subdomain.Name};\r");
            foreach (var location in subdomain.Locations)
            {
                lines.Add(GenerateLocation(location));
            }
            lines.Add("}\r");
            return string.Join("\r", lines);
        }

        public string GenerateLocation(Location location)
        {
            var lines = new List<string>();
            lines.Add($"location {location.Modifier.GetModifier()} {location.Match} {{");
            foreach (var setting in location.Settings)
            {
                lines.Add($"\t{setting.Directive.GetDirective()} {setting.Value};");
            }
            lines.Add("}\r");
            return string.Join("\r", lines.Select(x => $"\t{x}"));
        }

    }
}