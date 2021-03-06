﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BLL;
using BLL.BO;
using System;
using System.Collections.Generic;

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

            services.AddCors(o => o.AddPolicy("MyPolicy", builder => { builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader(); }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


               /* var facade = new BLLFacade();

                String[] Genres = { "Random", "Funny", "Sad", "Gaming", "Music", "Hobbies", "DIY" };

                foreach (var genre in Genres)
                {
                    GenreBO gen = new GenreBO()
                    {
                        Genre = genre
                    };
                    facade.GenreService.Add(gen);
                }


                String[] Authors = { "Billy Bob", "MacMoe", "SuperCoolDUde99", "Danny the Dude", "Me", "RealPerson", "KimK", "Someone Else" };


                Random rnd = new Random();


                for (int i = 1; i < 20; i++)
                {
                    VideoBO vid = new VideoBO()
                    {
                        Title = "Video " + i
                    };
                    int r2 = rnd.Next(Authors.Length);
                    vid.Author = Authors[r2];

                    r2 = rnd.Next(Genres.Length) + 1;

                    vid.GenreIDs = new List<int>() { (facade.GenreService.Get(r2).Id) };

                    facade.VideoService.Add(vid);
                }

                for (int i = 0; i <= 20; i++)
                {
                    facade.RentalService.Add(new RentalBO()
                    {
                        DeliveryDate = DateTime.Now.AddMonths(rnd.Next(5)),
                        RentalDate = DateTime.Now.AddMonths(-(rnd.Next(5))),
                        VideoId = facade.VideoService.Get(rnd.Next(facade.VideoService.GetCount())+1).ID
                    });
                }
                */
            }

            app.UseMvc();
        }
    }
}
