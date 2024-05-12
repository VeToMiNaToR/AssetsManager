using devdeer.AssetsManager.Logic.Ui.Services;
using devdeer.AssetsManager.Ui.WebApp.Components;

using Microsoft.Extensions.DependencyInjection;

using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddScoped(
    c => new HttpClient()
    {
        BaseAddress = new Uri("https://localhost:44301/api/v1/")
    });
builder.Services.AddScoped<AssetService>();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();