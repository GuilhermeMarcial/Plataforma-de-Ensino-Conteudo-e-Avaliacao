using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PlataformaDeEnsino.Presenter
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            this.Configuration = configuration;

        }
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {

        }
        public void ConfigureServices(IServiceCollection services)
        {

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
        }
    }
}
