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
using FNB.Ecommerce.Transversal.Mapper;
using FNB.Ecommerce.Infrastructure.Data;
using FNB.Ecommerce.Infrastructure.Repository;
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
using FNB.Ecommerce.Service.WebApi.Modules.Swagger;
using FNB.Ecommerce.Service.WebApi.Modules.Authentication;
using FluentAssertions.Common;
using FNB.Ecommerce.Service.WebApi.Modules.Mapper;
using FNB.Ecommerce.Service.WebApi.Modules.Feature;
using FNB.Ecommerce.Service.WebApi.Modules.Injection;
using FNB.Ecommerce.Service.WebApi.Modules.Validator;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFeature(this.configuration);
builder.Services.AddInjection(this.configuration);
builder.Services.AddMapper();
builder.Services.AddAuthentication1(this.configuration);

builder.Services.AddValidator();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

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



app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
