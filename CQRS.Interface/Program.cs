using CQRS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CQRS.Application.Commands.PersonCommands;
using CQRS.Domain.IRepositories;
using CQRS.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//add database
builder.Services.AddDbContext<CqrsDbContext>(option => option.UseSqlServer(builder.Configuration["ConnectionString"]));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
