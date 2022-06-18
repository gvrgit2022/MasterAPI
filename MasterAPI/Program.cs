using Master.Infrastructure.Models.Master;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models;
using MasterAPI;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigurationManager configuration = builder.Configuration;
IServiceCollection scollection = builder.Services;
builder.Services.AddLogging();
//builder.Services.AddDbContext<MasterContext>(
//options =>
//{
//    options.UseMySql(builder.Configuration.GetConnectionString("MasterDB"),
//    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
//});
Startup startup = new Startup(configuration);
startup.ConfigureServices(builder.Services);
var app = builder.Build();
startup.Configure(app, app.Environment);
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
