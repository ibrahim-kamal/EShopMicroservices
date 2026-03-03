using Ordering.Api;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
//----
//Infrastructure - EF Core //Application MediatR
//API - Carter, HealthChecks,

//----

builder.Services
.AddApplicationServices()
.AddInfrastructureServices(builder.Configuration)
.AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment()) {
    await app.InitialiseDatabaseAsync();
}

app.Run();
