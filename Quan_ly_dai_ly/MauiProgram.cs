﻿using Microsoft.Extensions.Logging;
using Quan_ly_dai_ly.Services;
using Quan_ly_dai_ly.DI;
using CommunityToolkit.Maui;

namespace Quan_ly_dai_ly
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.RegisterDependency();

            var appBuilder = builder.Build();
            _ = Task.Run(async () =>
            {
                using var scope = appBuilder.Services.CreateScope();
                await scope.ServiceProvider.GetRequiredService<DatabaseService>().InitializeAsync();
            });
            return appBuilder;
        }
    }
}
