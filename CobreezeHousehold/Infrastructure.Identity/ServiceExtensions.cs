using Application.Interfaces;
using Application.Wrappers;
using Domain.Settings;
using Infrastructure.Identity.Contexts;
using Infrastructure.Identity.Models;
using Infrastructure.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Identity
{
    public static class ServiceExtensions
    {
        public static void AddIdentityLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("IdentityConnection"),
                    builder => builder.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            services.AddTransient<IAccountService, AccountService>();

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                /*
                 * TODO: change when in prod
                 */
                options.RequireHttpsMetadata = false;
                options.SaveToken = false;

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"])),

                    ValidateAudience = true,
                    ValidAudience = configuration["JWTSettings:Audience"],

                    ValidateLifetime = true,

                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = context =>
                    {
                        context.NoResult();
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/plain";

                        return context.Response.WriteAsync(context.Exception.ToString());
                    },

                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";

                        string result = JsonSerializer.Serialize(new Response<string>("You are not authorized."));

                        return context.Response.WriteAsync(result);
                    },

                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";

                        string result = JsonSerializer.Serialize(new Response<string>("You are not authorized to access this resource."));

                        return context.Response.WriteAsync(result);
                    }
                };
            });
        }
    }
}