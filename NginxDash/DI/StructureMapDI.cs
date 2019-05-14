using System;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace NginxDash.DI
{
    public class StructureMapDI
    {
        public static IServiceProvider Configure(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(config =>
                {
                    config.Scan(_ =>
                        {
                            _.TheCallingAssembly();
                            _.Assembly("NginxDash");
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