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


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//   .AddJsonOptions(options =>
//{
//    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
//}); ;
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));

string myPolicy = "policyApiEcommerce";
builder.Services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins()
                                                                                   .AllowAnyHeader()
                                                                                   .AllowAnyMethod())) ;

//builder.Services.AddMvc()
//              .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
//               .AddJsonOptions(options => { options.SerializerSetting.ContactResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();});
builder.Services.AddSingleton<IConfiguration>();
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped<ICustomersApplication, CustomersApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
