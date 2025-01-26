using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using IdentityService;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Users(builder.Configuration);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    
builder.Services.AddShared();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontEndClient", builder =>
        builder.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:8080")
            .WithOrigins("https://localhost:7047")
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseShared();

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();