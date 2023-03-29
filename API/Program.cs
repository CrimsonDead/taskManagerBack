using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DBL.Repositories;
using DBL.Contexts;
using DBL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionString = builder.Environment.IsDevelopment() ?
    builder.Configuration.GetConnectionString("DefaultConnections") :
    builder.Configuration.GetConnectionString("DefaultConnections");

builder.Services.AddDbContext<ApplicationContext>(builder =>
{
    builder.UseSqlServer(connectionString);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Job>, JobRepository>();
builder.Services.AddScoped<IRepository<Project>, ProjectRepository>();

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
