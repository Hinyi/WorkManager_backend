using IdentityService;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Users(builder.Configuration);
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
app.UseShared();


app.UseAuthorization();
app.MapControllers();

app.Run();
