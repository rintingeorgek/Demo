using Plant360.Core.Models;
using Plant360.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DeviceService>();
builder.Services.AddSingleton<BillingCalculator>();

var app = builder.Build();

app.MapGet("/", () => "Plant360 API is running.");

app.MapGet("/health", () => Results.Ok(new { status = "Healthy", time = DateTime.UtcNow }));

app.MapGet("/devices", (DeviceService devices) => devices.GetAll());

app.MapGet("/devices/{id}", (string id, DeviceService devices) =>
    devices.FindById(id) is { } device ? Results.Ok(device) : Results.NotFound());

app.MapPost("/devices", (Device device, DeviceService devices) =>
{
    try
    {
        devices.Register(device);
        return Results.Created($"/devices/{device.Id}", device);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.MapGet("/billing/estimate", (decimal units, BillingCalculator billing) =>
{
    try
    {
        return Results.Ok(new { units, amount = billing.CalculateMonthlyBill(units) });
    }
    catch (ArgumentOutOfRangeException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.Run();
