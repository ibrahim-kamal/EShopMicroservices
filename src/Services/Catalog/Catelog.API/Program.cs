using BuildingBlocks.Behaviors;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
//builder.Services.AddTransient(typeof(ValidationBehavior<,>), typeof(ValidationBehavior<,>));


builder.Services.AddCarter();

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapCarter();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
