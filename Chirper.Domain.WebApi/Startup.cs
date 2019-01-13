using Chirper.Domain.WebApi.Cluster;
using Chirper.Domain.WebApi.Hubs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chirper.Domain.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder =>
            {
                builder.AllowAnyMethod().AllowAnyHeader()
                       //.WithOrigins("http://localhost:44314")
                       .AllowCredentials();
            }));
            services.AddSingleton(typeof(IActorSystemWrapper), typeof(ActorSystemWrapper));
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseSignalR(route =>
            {
                route.MapHub<ChirpHub>("/chirphub");
            });
            app.UseMvc();
        }
    }
}
