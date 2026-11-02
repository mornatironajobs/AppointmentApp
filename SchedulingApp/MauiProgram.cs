using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchedulingApp.Services;
using SchedulingApp.Shared.Data;
using SchedulingApp.Shared.Services;

namespace SchedulingApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Add device-specific services used by the SchedulingApp.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        builder.Services.AddMauiBlazorWebView();

        // Register the AppDbContext with a connection string
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "scheduling.db");
        builder.Services.AddDbContextFactory<AppDbContext>(o => o.UseSqlite($"Data Source={dbPath}"));

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

        using (var db = app.Services.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext())
        {
#if DEBUG
            // TODO: Remove after the schema is recreated; EnsureCreated does not update existing databases.
            db.Database.EnsureDeleted();
#endif
            db.Database.EnsureCreated();
        }

        return app;
    }
}
