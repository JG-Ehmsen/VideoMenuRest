using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BLL;
using BLL.BO;
using System;

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


                String[] Authors = { "Billy Bob", "MacMoe", "SuperCoolDUde99", "Danny the Dude", "Me", "RealPerson", "KimK", "Someone Else" };

                String[] Genres = { "Random", "Funny", "Sad", "Gaming", "Music", "Hobbies", "DYI" };

                Random rnd = new Random();


                for (int i = 1; i < 20; i++)
                {
                    VideoBO vid = new VideoBO()
                    {
                        Title = "Video " + i
                    };
                    int r2 = rnd.Next(Authors.Length);
                    vid.Author = Authors[r2];

                    r2 = rnd.Next(Genres.Length);
                    vid.Genre = Genres[r2];

                    facade.VideoService.Add(vid);
                }

                Random r = new Random();

                facade.RentalService.Add(new RentalBO()
                {
                    DeliveryDate = DateTime.Now.AddMonths(r.Next(5)),
                    RentalDate = DateTime.Now.AddMonths(-(r.Next(5)))
                });
                facade.RentalService.Add(new RentalBO()
                {
                    DeliveryDate = DateTime.Now.AddMonths(r.Next(5)),
                    RentalDate = DateTime.Now.AddMonths(-(r.Next(5)))
                });
                facade.RentalService.Add(new RentalBO()
                {
                    DeliveryDate = DateTime.Now.AddMonths(r.Next(5)),
                    RentalDate = DateTime.Now.AddMonths(-(r.Next(5)))
                });

            }

            app.UseMvc();
        }
    }
}
