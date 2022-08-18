namespace LazyTrader.Binance.Infrastructure.Services;

internal class NftService : INftService
{
	private readonly ILogger<NftService> _logger;
	private readonly IRequestService _requestService;
	private readonly IStatusService _statusService;
	
	public NftService(ILogger<NftService> logger, IRequestService requestService, IStatusService statusService)
	{
		_logger = logger;
		_requestService = requestService;
		_statusService = statusService;
	}
	
	public async Task<NftTransactionHistory> GetTransactionHistory(int orderType, long? startTime, long? endTime, int? limit, int? page)
	{
		_logger.LogInformation(">> GetTransactionHistory");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(orderType, nameof(orderType));
		ValidationUtils.ArgumentInsideRangeArray(orderType, nameof(orderType), new[] { 0, 1, 2, 3, 4 });
		ValidationUtils.ArgumentBetweenRange(limit, nameof(limit), 0, 50);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("orderType", orderType.ToString());

		if (startTime != null) queryValues.Add("startTime", limit.ToString());
		if (endTime != null) queryValues.Add("endTime", limit.ToString());
		if (limit != null) queryValues.Add("limit", limit.ToString());
		if (page != null) queryValues.Add("page", page.ToString());

		var result = await _requestService.Get<NftTransactionHistory>($"/sapi/v1/nft/history/transactions", queryValues);

		_logger.LogInformation("<< GetTransactionHistory");
		return result;
	}

	public async Task<NftDepositHistory> GetDepositHistory(long? startTime, long? endTime, int? limit, int? page)
	{
		_logger.LogInformation(">> GetDepositHistory");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentBetweenRange(limit, nameof(limit), 0, 50);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (startTime != null) queryValues.Add("startTime", limit.ToString());
		if (endTime != null) queryValues.Add("endTime", limit.ToString());
		if (limit != null) queryValues.Add("limit", limit.ToString());
		if (page != null) queryValues.Add("page", page.ToString());

		var result = await _requestService.Get<NftDepositHistory>($"/sapi/v1/nft/history/deposit", queryValues);

		_logger.LogInformation("<< GetDepositHistory");
		return result;
	}

	public async Task<NftWithdrawHistory> GetWithdrawHistory(long? startTime, long? endTime, int? limit, int? page)
	{
		_logger.LogInformation(">> GetWithdrawHistory");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentBetweenRange(limit, nameof(limit), 0, 50);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (startTime != null) queryValues.Add("startTime", limit.ToString());
		if (endTime != null) queryValues.Add("endTime", limit.ToString());
		if (limit != null) queryValues.Add("limit", limit.ToString());
		if (page != null) queryValues.Add("page", page.ToString());

		var result = await _requestService.Get<NftWithdrawHistory>($"/sapi/v1/nft/history/withdraw", queryValues);

		_logger.LogInformation("<< GetWithdrawHistory");
		return result;
	}

	public async Task<NftAsset> GetTokens(int? limit, int? page)
	{
		_logger.LogInformation(">> GetAssets");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentBetweenRange(limit, nameof(limit), 0, 50);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (limit != null) queryValues.Add("limit", limit.ToString());
		if (page != null) queryValues.Add("page", page.ToString());

		var result = await _requestService.Get<NftAsset>($"/sapi/v1/nft/user/getAsset", queryValues);

		_logger.LogInformation("<< GetAssets");
		return result;
	}
}