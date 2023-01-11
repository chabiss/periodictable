using Microsoft.Extensions.Logging;
using PeriodicTableData;
using PeriodicTableMaui.ViewModels;
using PeriodicTableMaui.Views;

namespace PeriodicTableMaui
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
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IMap>(Map.Default);
            builder.Services.AddSingleton<PeriodicTableDataEngine>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ElementDetail>();
            builder.Services.AddSingleton<ElementDetailViewModel>();
            return builder.Build();
        }
    }
}