var builder = WebApplication.CreateBuilder(args);


var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);



builder.Services.AddCarter();

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatelogInitialData>();

var app = builder.Build();

app.MapCarter();
app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler(options => { });

app.Run();
