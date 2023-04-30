using DevBBQ.Application.Services.Implementations;
using DevBBQ.Application.Services.Interfaces;
using DevBBQ.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Using memory database.
builder.Services.AddDbContext<DevBBQDbContext>(o => o.UseInMemoryDatabase("DevBBQDb"));

// Dependency Injection
builder.Services.AddScoped<IBBQService, BBQService>();
builder.Services.AddScoped<IBBQParticipantsService, BBQParticipantsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevBBQ.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Lécio Vilela",
            Email = "l3c1oo@gmail.com",
            Url = new Uri("https://linkedin.com/in/leciovilela")
        }
    });
    var xmlFile = "DevBBQ.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
