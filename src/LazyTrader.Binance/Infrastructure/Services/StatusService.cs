namespace LazyTrader.Binance.Infrastructure.Services;

internal class StatusService : IStatusService
{
	private readonly ILogger<StatusService> _logger;
	private readonly IRequestService _requestService;

	public StatusService(ILogger<StatusService> logger, IRequestService requestService)
	{
		_logger = logger;
		_requestService = requestService;
	}

	public async Task<ServiceStatus> GetServiceStatus()
	{
		_logger.LogInformation(">> GetServiceStatus");

		var result = await _requestService.Get<ServiceStatus>("/sapi/v1/system/status");

		_logger.LogInformation("<< GetServiceStatus");
		return result;
	}

	public async Task<ServerTime> GetServerTime()
	{
		_logger.LogInformation(">> GetServerTime");

		var result = await _requestService.Get<ServerTime>("/api/v3/time", null, false);

		_logger.LogInformation("<< GetServerTime");
		return result;
	}

	public async Task<bool> CheckServerStatus()
	{
		var result = await GetServiceStatus();
		return result.Status == 0;
	}
}