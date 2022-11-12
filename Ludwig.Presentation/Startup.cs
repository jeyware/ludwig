using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnTier;
using EnTier.Services;
using Ludwig.Presentation.Models;
using Ludwig.Presentation.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Ludwig.Presentation
{
    public class Startup
    {

        private StaticServer _frontEndServer = new StaticServer();
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddJsonFileUnitOfWork();
            
            services.AddTransient<ICrudService<UserStory,long>,UserStoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            

            _frontEndServer.ConfigurePreRouting(app, env);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            _frontEndServer.ConfigureMappings(app,env);
            
            app.IntroduceDotnetResolverToEnTier();
        }
    }
}