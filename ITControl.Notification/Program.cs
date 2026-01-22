using ITControl.Application.Notifications.Interfaces;
using ITControl.Application.Notifications.Services;
using ITControl.Application.Shared.Interfaces;
using ITControl.Application.Shared.Services;
using ITControl.Domain.Notifications.Interfaces;
using ITControl.Infrastructure.Notifications.Repositories;
using ITControl.Infrastructure.Shared.Contexts;
using ITControl.Infrastructure.Shared.Seeds;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>((options) =>
{
    options
        .UseSqlServer(connectionString)
        .UseAsyncSeeding(async (context, _, cancellationToken) =>
            await new ApplicationSeed(builder.Configuration)
                .SeedAsync(context, cancellationToken))
        .UseSeeding((context, _) =>
            new ApplicationSeed(builder.Configuration).Seed(context));
}
);
builder.Services.AddScoped<IWebSocketService, WebSocketService>();
builder.Services.AddScoped<INotificationsService, NotificationsService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<INotificationsRepository, NotificationsRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

app.UseWebSockets(webSocketOptions);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
