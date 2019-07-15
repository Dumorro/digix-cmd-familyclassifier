using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Digix.Raking.Domain.Core.DomainEvents;
using Digix.Raking.Domain.Services.Factories;
using Digix.Raking.EventDispatcher;
using Digix.Raking.Adapters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digix.Raking.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            return BuildDependencyInjectionProvider(services);
        }

        private static IServiceProvider BuildDependencyInjectionProvider(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            // Populate the container using the service collection
            builder.Populate(services);

            builder.RegisterAssemblyTypes(GetAssemblies()).AsImplementedInterfaces();

            IContainer applicationContainer = builder.Build();
            return new AutofacServiceProvider(applicationContainer);
        }

        private static Assembly[] GetAssemblies()
        {
            //return AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Digix.Raking")).ToArray();//TODO: change to parameter

            return new Assembly[] {
            // TODO: Add Registry Classes to eliminate reference to Infrastructure
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(DomainEvent)),
            Assembly.GetAssembly(typeof(ScoreFactory)),
            Assembly.GetAssembly(typeof(BaseDomainEventHandler)),
            Assembly.GetAssembly(typeof(AttendedFamiliesAdapter)),
            Assembly.GetAssembly(typeof(DistributedCacheAdapter))
            }; // TODO: Move to Infrastucture Registry }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
