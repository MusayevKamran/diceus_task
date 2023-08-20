﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace App.Api.Configurations
{
    /// <summary>
    ///  This static class sets up Swagger API documentation and UI for the application.
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        ///  Adds services for generating Swagger API documentation to provided IServiceCollection.
        ///  The method also configures authentication to be used with the Swagger UI.
        /// </summary>
        /// <param name="services">An instance of IServiceCollection to which the Swagger services will be added.</param>
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "App Project",
                    Description = "App API Swagger surface",
                    Contact = new OpenApiContact { Name = "Kamran Musayev", Email = "kamranmuayev90@gmail.cm", Url = new Uri("http://www.") },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://github.com/") }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            });
        }

        /// <summary>
        ///  Enables the middleware for serving the generated Swagger specification and the Swagger UI.
        /// </summary>
        /// <param name="app">An instance of IApplicationBuilder to which the Swagger middleware will be added.</param>
        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "App");
            });
        }
    }
}