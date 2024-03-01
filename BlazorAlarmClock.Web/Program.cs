using BlazorAlarmClock.Web.Components;
using BlazorAlarmClock.Web.Components.Pages;
using Blazored.LocalStorage;
using KristofferStrube.Blazor.MediaCaptureStreams;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", false, false);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton<BlazorAlarmClock.Web.Models.AlarmClock>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value) });
//var provider = new FileExtensionContentTypeProvider();
//provider.Mappings.Add(".mp3", "Data");
//builder.Services.Configure<StaticFileOptions>(options =>
//{
//    options.ContentTypeProvider = provider;
//});
builder.Services.AddMediaDevicesService();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
