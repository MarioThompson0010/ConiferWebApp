using ConiferWebApp.Client.Pages;
using ConiferWebApp.Components;
using ConiferWebApp.Services;
using ModelsProject;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


//////////////////////
builder.Services.AddHttpClient<IRegion, Region>("myapi", c =>
{
    c.BaseAddress = new Uri(builder.Configuration.GetConnectionString("LocalHostURI"));
    c.Timeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddSingleton<MyRegion>();
//builder.Services.AddSyncfusionBlazor();
//Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense();
/////////////////////////////////////////////////////   /

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ConiferWebApp.Client._Imports).Assembly);

app.Run();
