using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TodoPlan.API.Extensions;
using TodoPlan.API.Models;
using TodoPlan.API.Services;
using TodoPlan.API.Services.Interfaces;
using TodoPlan.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<TodoPlanContext>(options =>
{
    options.UseSqlServer(connectionString, x =>
    {
        x.MigrationsAssembly(Assembly.GetAssembly(typeof(TodoPlanContext))?.GetName().Name);
    });
});

builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

builder.Services.AddHttpClientServices(builder.Configuration);

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
