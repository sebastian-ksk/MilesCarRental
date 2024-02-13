﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace MilesCarRental.API
{
    public class Startup
    {


        public void ConfigureServices(IServiceCollection services)
        {


            string user = "sa";
            string password = "123456789";
            string server = "LOCALHOST";
            string database = "AdsProduccion";
            string connectionString = $"Server={server};Database={database};User Id={user};Password={password};TrustServerCertificate=true;";

            services.AddSingleton(connectionString);

            services.AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddEndpointsApiExplorer();

            //caching
            services.AddResponseCaching();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MilesCarRental.API", Version = "v1" });
            });
            services.AddMvcCore();
            services.AddEndpointsApiExplorer();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {    
            if (env.IsEnvironment("Local") || env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}