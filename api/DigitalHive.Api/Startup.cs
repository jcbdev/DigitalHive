using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalHive.Api.Data;
using DigitalHive.Api.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DigitalHive.Api
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

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .WithOrigins("https://localhost:3000", "http://localhost:5000", "https://localhost:5001", "http://localhost:3000", "https://127.0.0.1:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                     );
            });
            services.AddDbContext<DigitalHiveContext>(options =>
                options.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"], (builder) => {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(1), null);
                }));

            services.AddControllers();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRepository, Respository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DigitalHive.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOptions();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DigitalHive.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors("CorsPolicy");

            // app.UseAuthorization();
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //.RequireCors("MyPolicy");
            });
        }
    }
}
