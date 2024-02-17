
using Microsoft.Extensions.Options;
using TennisBookings.External;

namespace TennisBookings.BackgroundServices;

public class WeatherCacheService : BackgroundService
{
	private readonly IWeatherApiClient _weatherApiClient;
	private readonly IDistributedCache<WeatherResult> _cache;
	private readonly ILogger<WeatherCacheService> _logger;

	private readonly int _minutesInCache;
	private readonly int _refreshIntervalInSeconds;

	public WeatherCacheService(IWeatherApiClient weatherApiClient,
		IDistributedCache<WeatherResult> cache,
		IOptionsMonitor<ExternalServicesConfiguration> options,
		ILogger<WeatherCacheService> logger)
	{
		_weatherApiClient = weatherApiClient;
		_cache = cache;
		_logger = logger;
		_minutesInCache = options.Get(ExternalServicesConfiguration.WeatherApi).MinsToCache;
		_refreshIntervalInSeconds = _minutesInCache > 1 ? (_minutesInCache - 1) * 60 :30;
	}
	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	{
		throw new NotImplementedException();
	}
}
