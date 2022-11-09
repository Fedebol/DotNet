using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using FNB.Ecommerce.Transversal.Common;
using FNB.Ecommerce.Transvredal.Mapper;
using FNB.Ecommerce.Infrastructure.Data;
using FNB.Ecommerce.Infrastruture.Repository;
using FNB.Ecommerce.Infrastructure.Interface;
using FNB.Ecommerce.Domain.Interface;
using FNB.Ecommerce.Domain.Core;
using FNB.Ecommerce.Application.Interface;
using FNB.Ecommerce.Application.Main;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FNB.Ecommerce.Service.WebApi.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.FeatureManagement.FeatureFilters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FNB.Ecommerce.Transversal.Logging;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));

string myPolicy = "policyApiEcommerce";
IConfiguration? configuration;

builder.Services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins()
                                                                                   .AllowAnyHeader()
                                                                                   .AllowAnyMethod())) ;
builder.Services.AddMvc()
              .SetCompatibilityVersion(CompatibilityVersion.Latest);



var appSettingsSection = configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingsSection);


var appSetting = appSettingsSection.Get < AppSettings >

builder.Services.AddSingleton<IConfiguration>();
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomersApplication, CustomersApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IUsersApplication, UsersApplication>();
builder.Services.AddScoped<IUsersDomain, UsersDomain>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
var Issuer = appSettings.Issuer;
var Audience = appSettings.Audience; 

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                var userId = int.Parse(context.Principal.Identity.Name);
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
                }
                return Task.CompletedTask;
            }
        };
        x.RequireHttpsMetadata = false;
        x.SaveToken = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = Issuer,
            ValidateAudience = true,
            ValidAudience = Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {

        Title = "FNB Technology Service API Market",
        Description = "A simple example ASP.NET Core Web API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Federico Boldrini",
            Url = new Uri("https://example.com/"),
            Email = "",
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://example.com/license"),
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Authorization by API key.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Name = "Authorization"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {

            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api Ecommerce V1");
    });
}

app.UseCors(myPolicy);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
