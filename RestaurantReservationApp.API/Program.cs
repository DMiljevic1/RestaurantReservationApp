using Microsoft.EntityFrameworkCore;
using RestaurantReservationApp.API.Extensions;
using RestaurantReservationApp.Domain.Repositories;
using RestaurantReservationApp.Infrastructure.DatabaseContext;
using RestaurantReservationApp.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReservationApp.Application;
using System.Reflection;
using RestaurantReservationApp.Application.Common.User.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultDatabase")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddUserHandler).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
