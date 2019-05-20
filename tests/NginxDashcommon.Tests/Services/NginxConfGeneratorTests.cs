
using System.Collections.Generic;
using NginxDashCommon.Services;
using NginxDashCore.Data.Entities;
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
                Modifier = "",
                Match = "/"
            });

            Assert.Equal(expected, actual);
        }

    }
}