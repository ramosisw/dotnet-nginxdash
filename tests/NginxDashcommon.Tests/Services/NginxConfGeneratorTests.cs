
using System.Collections.Generic;
using NginxDashCommon.Services;
using NginxDashCore.Data.Entities;
using NginxDashCore.Enum;
using Xunit;

namespace NginxDashcommon.Tests.Services
{
    public class NginxConfGeneratorTests
    {
        public NginxConfGenerator service { get; }

        public NginxConfGeneratorTests()
        {
            service = new NginxConfGenerator();
        }

        [Theory]
        [InlineData("example.com", "include example.com/*.conf\r")]
        void GenerateDomain(string domain, string expected)
        {
            var actual = service.GenerateDomain(domain);
            Assert.Equal(expected, actual);
        }

        [Fact]
        void GenerateSubdomain()
        {
            var expected = "server {\r\tlisten 80;\r\tserver_name sub.example.com\r\troot /var/www/example.com/sub;\r\r}\r";
            var domain = "example.com";

            var actual = service.GenerateSubdomain(domain, new Subdomain
            {
                Name = "sub",
                IsDomainRoot = false,
            });
            Assert.Equal(expected, actual);
        }

        [Fact]
        void GenerateLocation()
        {
            var expected = "\tlocation  / {\r\t}\r";
            var actual = service.GenerateLocation(new Location
            {
                Modifier = LocationModifier.PREFIX,
                Match = "/"
            });

            Assert.Equal(expected, actual);
        }

        [Fact]
        void GenerateLocation_WithSetting()
        {
            var expected = "\tlocation  / {\r\t\tproxy_pass http://192.168.1.1:500;\r\t}\r";
            var actual = service.GenerateLocation(new Location
            {
                Modifier = LocationModifier.PREFIX,
                Match = "/",
                Settings = new List<LocationSetting> {
                    new LocationSetting {
                        Directive = NginxDirective.PROXY_PASS,
                        Value = "http://192.168.1.1:500"
                    }
                }
            });

            Assert.Equal(expected, actual);
        }

        [Fact]
        void GenerateLocation_WithSettings()
        {
            var expected = "\tlocation  / {\r\t\tproxy_pass http://192.168.1.1:500;\r\t\tproxy_set_header X-Real-IP $host;\r\t}\r";
            var actual = service.GenerateLocation(new Location
            {
                Modifier = LocationModifier.PREFIX,
                Match = "/",
                Settings = new List<LocationSetting> {
                    new LocationSetting {
                        Directive = NginxDirective.PROXY_PASS,
                        Value = "http://192.168.1.1:500"
                    },
                    new LocationSetting {
                        Directive = NginxDirective.PROXY_SET_HEADER,
                        Value = "X-Real-IP $host"
                    }
                }
            });

            Assert.Equal(expected, actual);
        }

    }
}