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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
