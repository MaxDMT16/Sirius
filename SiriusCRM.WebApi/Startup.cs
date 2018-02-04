using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SiriusCRM.Application;
using SiriusCRM.Database;
using SiriusCRM.Database.Context;
using SiriusCRM.Domain;
using SiriusCRM.WebApi.Middleware;

namespace SiriusCRM.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("SiriusDbContext");
            services.AddMvc();
            services.AddDbContext<SiriusDbContext>(builder => builder.UseSqlServer(connectionString));

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ApplicationModule>();
            containerBuilder.RegisterModule<DatabaseModule>();
            containerBuilder.RegisterModule<DomainModule>();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseMvc();
        }
    }
}
