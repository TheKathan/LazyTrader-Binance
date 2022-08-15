namespace LazyTrader.Binance.Infrastructure.Services;

internal class WalletService : IWalletService
{
	private readonly ILogger<WalletService> _logger;
	private readonly IRequestService _requestService;
	private readonly IStatusService _statusService;

	public WalletService(ILogger<WalletService> logger, IRequestService requestService, IStatusService statusService)
	{
		_logger = logger;
		_requestService = requestService;
		_statusService = statusService;
	}

	public async Task<List<CoinInformation>> GetCoinsInformation()
	{
		_logger.LogInformation(">> GetCoinsInformation");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var result = await _requestService.Get<List<CoinInformation>>($"/sapi/v1/capital/config/getall");

		_logger.LogInformation("<< GetCoinsInformation");
		return result;
	}

	public async Task<Snapshot> GetAccountSnapshot(string type, long? startTime, long? endTime, int? limit = 7)
	{
		_logger.LogInformation(">> GetAccountSnapshot");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(type, nameof(type));
		ValidationUtils.ArgumentBetweenRange(limit, nameof(limit), 7, 30);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("type", type);

		if (startTime != null) queryValues.Add("startTime", limit.ToString());
		if (endTime != null) queryValues.Add("endTime", limit.ToString());
		if (limit != null) queryValues.Add("limit", limit.ToString());

		var result = await _requestService.Get<Snapshot>($"/sapi/v1/accountSnapshot", queryValues);

		_logger.LogInformation("<< GetAccountSnapshot");
		return result;
	}

	public async Task<bool> DisableFastWithdrawSwitch()
	{
		_logger.LogInformation(">> DisableFastWithdrawSwitch");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		await _requestService.Post($"/sapi/v1/account/disableFastWithdrawSwitch");

		_logger.LogInformation("<< DisableFastWithdrawSwitch");
		return true;
	}

	public async Task<bool> EnableFastWithdrawSwitch()
	{
		_logger.LogInformation(">> EnableFastWithdrawSwitch");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		await _requestService.Post($"/sapi/v1/account/enableFastWithdrawSwitch");

		_logger.LogInformation("<< EnableFastWithdrawSwitch");
		return true;
	}

	public async Task<WithdrawRequest> Withdraw(string coin, string address, decimal amount, string? withdrawOrderId,
		string? network, string? addressTag, bool? transactionFeeFlag, string? name, int? walletType)
	{
		_logger.LogInformation(">> Withdraw");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(coin, nameof(coin));
		ValidationUtils.ArgumentNotNull(address, nameof(address));
		ValidationUtils.ArgumentNotNull(amount, nameof(amount));

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("coin", coin);
		queryValues.Add("address", address);
		queryValues.Add("amount", amount.ToString(CultureInfo.InvariantCulture));

		if (withdrawOrderId != null) queryValues.Add("withdrawOrderId", withdrawOrderId);
		if (network != null) queryValues.Add("network", network);
		if (addressTag != null) queryValues.Add("addressTag", addressTag);
		if (transactionFeeFlag != null) queryValues.Add("transactionFeeFlag", transactionFeeFlag.ToString());
		if (name != null) queryValues.Add("name", name.Replace(" ", "%20"));
		if (walletType != null)
		{
			ValidationUtils.ArgumentInsideRangeArray((int)walletType, nameof(walletType), new[] { 0, 1 });
			queryValues.Add("walletType", walletType.ToString());
		}

		var result = await _requestService.Post<WithdrawRequest>($"/sapi/v1/capital/withdraw/apply", queryValues);

		_logger.LogInformation("<< Withdraw");
		return result;
	}

	public async Task<List<Deposit>> GetDepositHistory(string? coin, int? status, long? startTime, long? endTime,
		int? offset = 0, int? limit = 1000)
	{
		_logger.LogInformation(">> GetDepositHistory");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (coin != null) queryValues.Add("coin", coin);
		if (status != null)
		{
			ValidationUtils.ArgumentInsideRangeArray((int)status, nameof(status), new[] { 0, 1, 6 });
			queryValues.Add("status", status.ToString());
		}

		if (startTime != null) queryValues.Add("startTime", startTime.ToString());
		if (endTime != null) queryValues.Add("endTime", endTime.ToString());
		if (offset != null) queryValues.Add("offset", offset.ToString());
		if (limit != null)
		{
			ValidationUtils.ArgumentBelowLimit(limit, nameof(limit), 1000);
			queryValues.Add("limit", limit.ToString());
		}

		var result = await _requestService.Get<List<Deposit>>($"/sapi/v1/capital/deposit/hisrec", queryValues);

		_logger.LogInformation("<< GetDepositHistory");
		return result;
	}

	public async Task<List<Withdraw>> GetWithdrawHistory(string? coin, int? status, long? startTime, long? endTime,
		int? offset, int? limit)
	{
		_logger.LogInformation(">> GetWithdrawHistory");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (coin != null) queryValues.Add("coin", coin);
		if (status != null)
		{
			ValidationUtils.ArgumentInsideRangeArray((int)status, nameof(status), new[] { 0, 1, 2, 3, 4, 5, 6 });
			queryValues.Add("status", status.ToString());
		}

		if (startTime != null) queryValues.Add("startTime", startTime.ToString());
		if (endTime != null) queryValues.Add("endTime", endTime.ToString());
		if (offset != null) queryValues.Add("offset", offset.ToString());
		if (limit != null)
		{
			ValidationUtils.ArgumentBelowLimit(limit, nameof(limit), 1000);
			queryValues.Add("limit", limit.ToString());
		}

		var result = await _requestService.Get<List<Withdraw>>($"/sapi/v1/capital/withdraw/history", queryValues);

		_logger.LogInformation("<< GetWithdrawHistory");
		return result;
	}

	public async Task<Address> GetDepositAddress(string coin, string? network)
	{
		_logger.LogInformation(">> GetDepositAddress");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("coin", coin);

		if (network != null) queryValues.Add("network", network);

		var result = await _requestService.Get<Address>($"/sapi/v1/capital/deposit/address", queryValues);

		_logger.LogInformation("<< GetDepositAddress");
		return result;
	}

	public async Task<AccountStatus> GetAccountStatus()
	{
		_logger.LogInformation(">> GetDepositAddress");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var result = await _requestService.Get<AccountStatus>($"/sapi/v1/account/status");

		_logger.LogInformation("<< GetDepositAddress");
		return result;
	}

	public async Task<AccountApiStatus> GetAccountApiTradingStatus()
	{
		_logger.LogInformation(">> GetAccountApiTradingStatus");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var result = await _requestService.Get<AccountApiStatus>($"/sapi/v1/account/apiTradingStatus");

		_logger.LogInformation("<< GetAccountApiTradingStatus");
		return result;
	}

	public async Task<DustLog> GetDustLog(long? startTime, long? endTime)
	{
		_logger.LogInformation(">> GetDustLog");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (startTime != null) queryValues.Add("startTime", startTime.ToString());
		if (endTime != null) queryValues.Add("endTime", endTime.ToString());

		var result = await _requestService.Get<DustLog>($"/sapi/v1/asset/dribblet", queryValues);

		_logger.LogInformation("<< GetDustLog");
		return result;
	}

	public async Task<ConvertableAsset> GetBnbConvertableAssets()
	{
		_logger.LogInformation(">> GetBnbConvertableAssets");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var result = await _requestService.Post<ConvertableAsset>($"/sapi/v1/asset/dust-btc");

		_logger.LogInformation("<< GetBnbConvertableAssets");
		return result;
	}

	public async Task<DustTransfer> DustTransfer(string asset)
	{
		_logger.LogInformation(">> DustTransfer");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("asset", asset);

		var result = await _requestService.Post<DustTransfer>($"/sapi/v1/asset/dust", queryValues);

		_logger.LogInformation("<< DustTransfer");
		return result;
	}

	public async Task<DividendRecord> GetAssetDividendRecords(string? asset, long? startTime, long? endTime, int? limit)
	{
		_logger.LogInformation(">> GetAssetDividendRecords");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (asset != null) queryValues.Add("asset", asset);
		if (startTime != null) queryValues.Add("startTime", startTime.ToString());
		if (endTime != null) queryValues.Add("endTime", endTime.ToString());
		if (limit != null)
		{
			ValidationUtils.ArgumentBelowLimit(limit, nameof(limit), 500);
			queryValues.Add("limit", limit.ToString());
		}

		var result = await _requestService.Get<DividendRecord>($"/sapi/v1/asset/assetDividend", queryValues);

		_logger.LogInformation("<< GetAssetDividendRecords");
		return result;
	}

	public async Task<AssetDetail> GetAssetDetail(string? asset)
	{
		_logger.LogInformation(">> GetAssetDetail");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (asset != null) queryValues.Add("asset", asset);

		var result = await _requestService.Get<AssetDetail>($"/sapi/v1/asset/assetDetail", queryValues);

		_logger.LogInformation("<< GetAssetDetail");
		return result;
	}

	public async Task<List<TradeFee>> GetTradeFee(string? symbol)
	{
		_logger.LogInformation(">> GetTradeFee");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (symbol != null) queryValues.Add("symbol", symbol);

		var result = await _requestService.Get<List<TradeFee>>($"/sapi/v1/asset/tradeFee", queryValues);

		_logger.LogInformation("<< GetTradeFee");
		return result;
	}

	public async Task<UserUniversalTransfer> UserUniversalTransfer(string type, string asset, decimal amount,
		string? fromSymbol, string? toSymbol)
	{
		_logger.LogInformation(">> UserUniversalTransfer");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(type, nameof(type));
		ValidationUtils.ArgumentNotNull(asset, nameof(asset));
		ValidationUtils.ArgumentNotNull(amount, nameof(amount));
		ValidationUtils.UserUniversalTransferRequestIsCorrect(type, fromSymbol, toSymbol);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("fromSymbol", fromSymbol);
		queryValues.Add("toSymbol", toSymbol);

		var result = await _requestService.Post<UserUniversalTransfer>($"/sapi/v1/asset/transfer", queryValues);

		_logger.LogInformation("<< UserUniversalTransfer");
		return result;
	}

	public async Task<UserUniversalTransferHistory> GetUserUniversalTransferHistory(string type, long? startTime,
		long? endTime, int? current, int? size, string? fromSymbol, string? toSymbol)
	{
		_logger.LogInformation(">> GetUserUniversalTransferHistory");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(type, nameof(type));
		ValidationUtils.ArgumentBelowLimit(size, nameof(size), 100);
		ValidationUtils.UserUniversalTransferRequestIsCorrect(type, fromSymbol, toSymbol);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		if (startTime != null) queryValues.Add("startTime", startTime.ToString());
		if (endTime != null) queryValues.Add("endTime", endTime.ToString());
		if (current != null) queryValues.Add("current", current.ToString());
		if (size != null) queryValues.Add("size", size.ToString());
		if (fromSymbol != null) queryValues.Add("fromSymbol", fromSymbol);
		if (toSymbol != null) queryValues.Add("toSymbol", toSymbol);

		var result = await _requestService.Get<UserUniversalTransferHistory>($"/sapi/v1/asset/transfer", queryValues);

		_logger.LogInformation("<< GetUserUniversalTransferHistory");
		return result;
	}

	public async Task<List<UserAsset>> GetFundingWallet(string? asset, string? needBtcValuation)
	{
		_logger.LogInformation(">> GetFundingWallet");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (asset != null) queryValues.Add("asset", asset);
		if (needBtcValuation != null) queryValues.Add("needBtcValuation", needBtcValuation);

		var result = await _requestService.Post<List<UserAsset>>($"/sapi/v1/asset/get-funding-asset", queryValues);

		_logger.LogInformation("<< GetFundingWallet");
		return result;
	}

	public async Task<List<UserAsset>> GetUserAssets(string? asset, string? needBtcValuation)
	{
		_logger.LogInformation(">> GetUserAssets");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (asset != null) queryValues.Add("asset", asset);
		if (needBtcValuation != null) queryValues.Add("needBtcValuation", needBtcValuation);

		var result = await _requestService.Post<List<UserAsset>>($"/sapi/v3/asset/getUserAsset", queryValues);

		_logger.LogInformation("<< GetUserAssets");
		return result;
	}

	public async Task<ApiKeyPermission> GetApiKeyPermissions()
	{
		_logger.LogInformation(">> GetApiKeyPermissions");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var result = await _requestService.Get<ApiKeyPermission>($"/sapi/v1/account/apiRestrictions");

		_logger.LogInformation("<< GetApiKeyPermissions");
		return result;
	}
}