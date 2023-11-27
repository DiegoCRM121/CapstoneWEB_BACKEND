using Microsoft.EntityFrameworkCore;
using CapstoneWEB.CORE.Entities;
using CapstoneWEB.CORE.Interfaces;
using CapstoneWEB.CORE.Services;
using CapstoneWEB.INFRASTRUCTURE.Data;
using CapstoneWEB.INFRASTRUCTURE.Repositories;
using CapstoneWEB.INFRASTRUCTURE.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var _config = builder.Configuration;
var _cnx = _config.GetConnectionString("DevConnection");
builder
    .Services
    .AddDbContext<CapstoneDbContext>
    (options => options.UseSqlServer(_cnx));
builder.Services.AddSharedInfrastructure(_config);
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IFileRepository, FileRepository>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IEmotionDetailRepository, EmotionDetailRepository>();

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        var urlFrontend = "http://localhost:9000/";
        builder//.WithOrigins(urlFrontend)
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});
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
app.UseCors();
app.MapControllers();

app.Run();