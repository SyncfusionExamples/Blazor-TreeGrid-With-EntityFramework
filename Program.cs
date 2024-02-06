using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TreeGrdiWithEF.Data;
using Syncfusion.Blazor;
using Newtonsoft.Json.Serialization;
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA4MzQwNUAzMjM0MmUzMDJlMzBLSjdIWHA2T1pZV09IRjAyeDFDd21ZKzFCSWdId2JxTDdGOVErUzFFNmVVPQ==");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
