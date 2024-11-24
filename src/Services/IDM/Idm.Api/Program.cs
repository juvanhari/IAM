using Idm.Api;
using Idm.Application;
using Idm.Infrastructure;
using Idm.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Services to the DI Container

builder.Services.
     AddApplicationServices(builder.Configuration)
    .AddInfraStructureServices(builder.Configuration)
    .AddPresentationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP Request Pipeline

app.UseApiServices();

// This is my extension method for running migration when application starts first time.
if (app.Environment.IsDevelopment())
{
    await app.IntialiseDatabaseAsync();
}
MapsterConfiguration.RegisterMappings();

app.Run();
