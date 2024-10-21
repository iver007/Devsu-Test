using Application;
using Application.Services;
using Infrastructure;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Web.Api.Middleware;
using Web.Api.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ClienteService>();
builder.Services.AddSingleton<ExceptionHandlingMiddleware>();
builder.Services.AddApplicationRegistrations();
builder.Services.AddInfrastructureRegistrations();

//services.Configure<QrUtilConfig>(builder.Configuration.GetSection("Service2Url"));
builder.Services.AddMassTransit( x => {
    x.UsingRabbitMq((context, configurator) =>
    {
        var service2Settings = builder.Configuration.GetSection(nameof(Service2Settings)).Get<Service2Settings>();
        var rabbitMQSettings = builder.Configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();
        configurator.Host(rabbitMQSettings.Host);
        configurator.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter(service2Settings.Host, false));
    });
});
builder.Services.AddMassTransitHostedService();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();