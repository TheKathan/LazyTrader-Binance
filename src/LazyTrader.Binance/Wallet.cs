namespace LazyTrader.Binance;

public class Wallet
{
	private readonly ILogger<Wallet> _logger;
	private readonly IWalletService _walletService;

	public Wallet(ILogger<Wallet> logger, IWalletService walletService)
	{
		_logger = logger;
		_walletService = walletService;
	}

	public async Task<List<CoinInformation>> GetCoinsInformation()
	{
		_logger.LogInformation("> GetCoinsInformation");

		var result = await _walletService.GetCoinsInformation();

		_logger.LogInformation("< GetCoinsInformation");
		return result;
	}

	public async Task<Snapshot> GetAccountSnapshot(string type, long? startTime, long? endTime, int? limit)
	{
		_logger.LogInformation("> GetAccountSnapshot");

		var result = await _walletService.GetAccountSnapshot(type, startTime, endTime, limit);

		_logger.LogInformation("< GetAccountSnapshot");
		return result;
	}

	public async Task<bool> DisableFastWithdrawSwitch()
	{
		_logger.LogInformation("> DisableFastWithdrawSwitch");

		var result = await _walletService.DisableFastWithdrawSwitch();

		_logger.LogInformation("< DisableFastWithdrawSwitch");
		return result;
	}

	public async Task<bool> EnableFastWithdrawSwitch()
	{
		_logger.LogInformation("> EnableFastWithdrawSwitch");

		var result = await _walletService.EnableFastWithdrawSwitch();

		_logger.LogInformation("< EnableFastWithdrawSwitch");
		return result;
	}

	public async Task<WithdrawRequest> Withdraw(string coin, string address, decimal amount, string? withdrawOrderId,
		string? network, string? addressTag, bool? transactionFeeFlag, string? name, int? walletType)
	{
		_logger.LogInformation("> Withdraw");

		var result = await _walletService.Withdraw(coin, address, amount, withdrawOrderId, network, addressTag,
			transactionFeeFlag, name, walletType);

		_logger.LogInformation("< Withdraw");
		return result;
	}

	public async Task<List<Deposit>> GetDepositHistory(string? coin, int? status, long? startTime, long? endTime,
		int? offset, int? limit)
	{
		_logger.LogInformation("> GetDepositHistory");

		var result = await _walletService.GetDepositHistory(coin, status, startTime, endTime, offset, limit);

		_logger.LogInformation("< GetDepositHistory");
		return result;
	}

	public async Task<List<Withdraw>> GetWithdrawHistory(string? coin, int? status, long? startTime, long? endTime,
		int? offset, int? limit)
	{
		_logger.LogInformation("> GetWithdrawHistory");

		var result = await _walletService.GetWithdrawHistory(coin, status, startTime, endTime, offset, limit);

		_logger.LogInformation("< GetWithdrawHistory");
		return result;
	}

	public async Task<Address> GetDepositAddress(string coin, string? network)
	{
		_logger.LogInformation("> GetDepositAddress");

		var result = await _walletService.GetDepositAddress(coin, network);

		_logger.LogInformation("< GetDepositAddress");
		return result;
	}

	public async Task<AccountStatus> GetAccountStatus()
	{
		_logger.LogInformation("> GetAccountStatus");

		var result = await _walletService.GetAccountStatus();

		_logger.LogInformation("< GetAccountStatus");
		return result;
	}

	public async Task<AccountApiStatus> GetAccountApiTradingStatus()
	{
		_logger.LogInformation("> GetAccountApiTradingStatus");

		var result = await _walletService.GetAccountApiTradingStatus();

		_logger.LogInformation("< GetAccountApiTradingStatus");
		return result;
	}

	public async Task<DustLog> GetDustLog(long? startTime, long? endTime)
	{
		_logger.LogInformation("> GetDustLog");

		var result = await _walletService.GetDustLog(startTime, endTime);

		_logger.LogInformation("< GetDustLog");
		return result;
	}

	public async Task<ConvertableAsset> GetBnbConvertableAssets()
	{
		_logger.LogInformation("> GetBnbConvertableAssets");

		var result = await _walletService.GetBnbConvertableAssets();

		_logger.LogInformation("< GetBnbConvertableAssets");
		return result;
	}

	public async Task<DustTransfer> DustTransfer(string asset)
	{
		_logger.LogInformation("> DustTransfer");

		var result = await _walletService.DustTransfer(asset);

		_logger.LogInformation("< DustTransfer");
		return result;
	}

	public async Task<DividendRecord> GetAssetDividendRecords(string? asset, long? startTime, long? endTime, int? limit)
	{
		_logger.LogInformation("> GetAssetDividendRecords");

		var result = await _walletService.GetAssetDividendRecords(asset, startTime, endTime, limit);

		_logger.LogInformation("< GetAssetDividendRecords");
		return result;
	}

	public async Task<AssetDetail> GetAssetDetail(string? asset)
	{
		_logger.LogInformation("> GetAssetDetail");

		var result = await _walletService.GetAssetDetail(asset);

		_logger.LogInformation("< GetAssetDetail");
		return result;
	}

	public async Task<List<TradeFee>> GetTradeFee(string? symbol)
	{
		_logger.LogInformation("> GetTradeFee");

		var result = await _walletService.GetTradeFee(symbol);

		_logger.LogInformation("< GetTradeFee");
		return result;
	}

	public async Task<UserUniversalTransfer> UserUniversalTransfer(string type, string asset, decimal amount,
		string? fromSymbol, string? toSymbol)
	{
		_logger.LogInformation("> UserUniversalTransfer");

		var result = await _walletService.UserUniversalTransfer(type, asset, amount, fromSymbol, toSymbol);

		_logger.LogInformation("< UserUniversalTransfer");
		return result;
	}

	public async Task<UserUniversalTransferHistory> GetUserUniversalTransferHistory(string type, long? startTime,
		long? endTime, int? current, int? size, string? fromSymbol, string? toSymbol)
	{
		_logger.LogInformation("> GetUserUniversalTransferHistory");

		var result =
			await _walletService.GetUserUniversalTransferHistory(type, startTime, endTime, current, size, fromSymbol,
				toSymbol);

		_logger.LogInformation("< GetUserUniversalTransferHistory");
		return result;
	}

	public async Task<List<UserAsset>> GetFundingWallet(string? asset, string? needBtcValuation)
	{
		_logger.LogInformation("> GetFundingWallet");

		var result = await _walletService.GetFundingWallet(asset, needBtcValuation);

		_logger.LogInformation("< GetFundingWallet");
		return result;
	}

	public async Task<List<UserAsset>> GetUserAssets(string? asset, string? needBtcValuation)
	{
		_logger.LogInformation("> GetUserAssets");

		var result = await _walletService.GetUserAssets(asset, needBtcValuation);

		_logger.LogInformation("< GetUserAssets");
		return result;
	}

	public async Task<ApiKeyPermission> GetApiKeyPermissions()
	{
		_logger.LogInformation("> GetApiKeyPermissions");

		var result = await _walletService.GetApiKeyPermissions();

		_logger.LogInformation("< GetApiKeyPermissions");
		return result;
	}
}