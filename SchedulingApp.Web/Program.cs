using Microsoft.EntityFrameworkCore;
using SchedulingApp.Shared.Data;
using SchedulingApp.Shared.Services;
using SchedulingApp.Web.Components;
using SchedulingApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the SchedulingApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

// Register the AppDbContext with a connection string
builder.Services.AddDbContextFactory<AppDbContext>(o => o.UseSqlite("Data Source=scheduling.db"));

var app = builder.Build();

//Let the web app find routes in the RCL. In SchedulingApp.Web/Program.cs:
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .AddAdditionalAssemblies(typeof(SchedulingApp.Shared._Imports).Assembly);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(
        typeof(SchedulingApp.Shared._Imports).Assembly);

app.Run();
