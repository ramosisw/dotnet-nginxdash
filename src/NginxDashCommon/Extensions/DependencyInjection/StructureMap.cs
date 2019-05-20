using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NginxDashCore.Data;
using StructureMap;

namespace NginxDashCommon.Extensions.DependencyInjection
{
    public static class StructureMap
    {
        public static IServiceProvider ConfigureNginxDash(this IServiceCollection services, IConfiguration confiiguration)
        {
            services.AddDbContext<NginxDashContext>(options => options.UseSqlite(confiiguration.GetConnectionString("NginxDashContext")));
            var container = new Container();
            container.Configure(config =>
                {
                    config.Scan(_ =>
                        {
                            _.TheCallingAssembly();
                            _.Assembly("NginxDash");
                            _.Assembly("NginxDashCommon");
                            _.Assembly("NginxDashCore");
                            _.WithDefaultConventions();
                        }
                    );
                    config.Populate(services);
                }
            );

            return container.GetInstance<IServiceProvider>();
        }
    }
}