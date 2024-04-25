using ConiferWebApp.Client.Pages;
using ConiferWebApp.Components;
using ConiferWebApp.Data;
using ConiferWebApp.Repository;
using ConiferWebApp.Services;
using Microsoft.Extensions.Options;
using ModelsProject;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();


//////////////////////
builder.Services.AddScoped<IZoneRepository, ZoneRepository>();
builder.Services.AddControllers();

builder.Services.AddSingleton<IRegion, Region>();
builder.Services.AddSingleton<IState, State>();
builder.Services.AddSingleton<IZone, Zone>();
builder.Services.AddDbContext<ApplicationDbContext>(
    //options =>


    //options.UseSqlServer("")
    //normally set the connection string here
    ); ;

builder.Services.AddHttpClient<IZone, Zone>("myapi", c =>
{
    c.BaseAddress = new Uri(builder.Configuration.GetConnectionString("LocalHostURI"));
    c.Timeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddHttpClient<IRegion, Region>("myapireg", c =>
{
    c.BaseAddress = new Uri(builder.Configuration.GetConnectionString("LocalHostURI"));
    c.Timeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddHttpClient<IState, State>("myapist", c =>
{
    c.BaseAddress = new Uri(builder.Configuration.GetConnectionString("LocalHostURI"));
    c.Timeout = TimeSpan.FromMinutes(10);
});


//using System.Net.Http.Headers;
//var client = new HttpClient();
//var request = new HttpRequestMessage
//{
//    Method = HttpMethod.Get,
//    RequestUri = new Uri("https://national-weather-service.p.rapidapi.com/zones/%7Btype%7D/%7BzoneId%7D/forecast"),
//    Headers =
//    {
//        { "X-RapidAPI-Key", "a2b5d3b684mshabbf5412b1d3507p11b0a1jsnd2cd92016a40" },
//        { "X-RapidAPI-Host", "national-weather-service.p.rapidapi.com" },
//    },
//};
//using (var response = await client.SendAsync(request))
//{
//    response.EnsureSuccessStatusCode();
//    var body = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(body);
//}


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

////////////////////////
app.MapControllers();
/////////////////////////////////////////////////////

app.Run();


