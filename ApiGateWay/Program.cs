using ApiGateWay.Aggregators;
using ApiGateWay.Handlers;

using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Host.ConfigureAppConfiguration(( hosting, config ) => {
    config.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
});
builder.Services.AddOcelot()
    .AddDelegatingHandler<RemoveEncodingDelegatingHandler>(true)
    .AddSingletonDefinedAggregator<UsersPostsAggregator>();

var app = builder.Build();

app.UseOcelot().Wait();

app.UseHttpsRedirection();


app.Run();
