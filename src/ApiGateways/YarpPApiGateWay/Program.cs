var builder = WebApplication.CreateBuilder(args);

// add Services to the container
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// configure the Http request pipline

app.MapReverseProxy();

app.Run();
