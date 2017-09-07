using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BLL;
using BLL.BO;

namespace VideoRestAPI
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                var facade = new BLLFacade();
                facade.VideoService.Add(
                    new VideoBO()
                    {
                        Title = "HEhehe",
                        Author = "hashdsah",
                        Genre = "Random"
                    });
                facade.VideoService.Add(
                    new VideoBO()
                    {
                        Title = "asdasd",
                        Author = "hasda",
                        Genre = "ddass"
                    });
            }

            app.UseMvc();
        }
    }
}
