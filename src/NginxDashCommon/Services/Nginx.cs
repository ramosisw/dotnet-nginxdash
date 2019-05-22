using NginxDashCommon.Models.Subdomain;
using NginxDashCommon.Models.Location;
using Microsoft.EntityFrameworkCore;
using NginxDashCommon.Models.Domain;
using NginxDashCore.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using NginxDashCore.Data.Uow;
using NginxDashCore.Data;
using System.Linq;
using System.Text;
using System.IO;
using System;

namespace NginxDashCommon.Services
{
    public class Nginx : INginx
    {
        private string _ngixRootRoute = @"/etc/nginx/conf.d";
        private readonly INginxDashUow _uow;
        private readonly INginxConfGenerator _confGenerator;

        public Nginx(INginxDashUow uow, INginxConfGenerator confGenerator)
        {
            _uow = uow;
            _confGenerator = confGenerator;
        }

        public async Task<bool> SetupDomainAsync(DomainModel domain)
        {
            Directory.CreateDirectory(_ngixRootRoute);
            using (var file = File.Create($"{_ngixRootRoute}/{domain.Name}.conf"))
            {
                var bytes = Encoding.UTF8.GetBytes(_confGenerator.GenerateDomain(domain.Name));
                await file.WriteAsync(bytes, 0, bytes.Length);
            }
            return true;
        }

        public bool TestConfig()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SetupSubdomainAsync(Guid domainId, SubdomainModel subdomainModel)
        {
            var domainName = (await _uow.DomainsRepository.Entities.FirstOrDefaultAsync(x => x.Id == domainId))?.Name;
            var domainDirPath = $"{_ngixRootRoute}/{domainName}";
            Directory.CreateDirectory(domainDirPath);
            var subdomain = new Subdomain
            {
                Name = subdomainModel.Name,
                ForceHttps = subdomainModel.ForceHttps,
                IsDomainRoot = subdomainModel.IsDomainRoot,
                Locations = subdomainModel.Locations.Select(l => new Location
                {
                    Match = l.Match,
                    Modifier = l.Modifier,
                    Settings = l.Settings.Select(s => new LocationSetting
                    {
                        Directive = s.Directive,
                        Value = s.Value
                    }).ToList()
                }).ToList()
            };

            using (var file = File.Create($"{domainDirPath}/{subdomain.Name}.conf"))
            {
                var bytes = Encoding.UTF8.GetBytes(_confGenerator.GenerateSubdomain(domainName, subdomain));
                await file.WriteAsync(bytes, 0, bytes.Length);
            }
            return true;
        }
    }
}