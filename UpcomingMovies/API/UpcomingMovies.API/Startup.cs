using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using UpcomingMovies.API.Bootstrap;
using UpcomingMovies.API.Core.Data;
using UpcomingMovies.API.Core.Services;
using UpcomingMovies.API.Core.Services.Interfaces;
using UpcomingMovies.API.Infrastructure.Repositories;

namespace UpcomingMovies.MobileAppService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        public IContainer ApplicationContainer { get; private set; }

        public IConfigurationRoot Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            var builder = new ContainerBuilder();

            builder.Register(c =>
             new Mapper(AutoMapperConfiguration.Configure()))
            .As<IMapper>()
            .InstancePerLifetimeScope();

            builder.Populate(services);

            builder.RegisterType<UpcomingMovieRepository>().As<IUpcomingMovieRepository>();
            builder.RegisterType<MovieDetailRepository>().As<IMovieDetailRepository>();

            builder.RegisterType<UpcomingMoviesService>().As<IUpcomingMoviesService>();
            builder.RegisterType<MovieDetailsService>().As<IMovieDetailsService>();

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.Run(async (context) => await Task.Run(() => context.Response.Redirect("/swagger")));
        }
    }
}
