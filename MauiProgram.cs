using Microsoft.Extensions.Logging;
using Services;

namespace AppLanches;

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
		builder.Services.AddHttpClient();
		builder.Services.AddSingleton<ApiService>(provider =>
		{
			var httpClient = provider.GetRequiredService<HttpClient>();
			var logger = provider.GetRequiredService<ILogger<ApiService>>();
			string baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5284/" : "http://localhost:5284/";
			return new ApiService(httpClient, baseUrl, logger);
		});

		return builder.Build();
	}
}
