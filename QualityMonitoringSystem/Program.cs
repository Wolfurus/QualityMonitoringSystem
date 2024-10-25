using Microsoft.EntityFrameworkCore;
using QualityMonitoringSystem.Components;
using QualityMonitoringSystem.Core;
using QualityMonitoringSystem.Core.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<QualityMonitoringSystemContext>(
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("QualityMonitoringSystem")));

builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddTransient<IQualityMonitorEfRepository, QualityMonitorEfRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
