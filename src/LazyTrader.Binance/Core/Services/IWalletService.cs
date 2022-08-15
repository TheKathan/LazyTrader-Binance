namespace LazyTrader.Binance.Core.Services;

public interface IWalletService
{
	Task<List<CoinInformation>> GetCoinsInformation();
	Task<Snapshot> GetAccountSnapshot(string type, long? startTime, long? endTime, int? limit);
	Task<bool> DisableFastWithdrawSwitch();
	Task<bool> EnableFastWithdrawSwitch();

	Task<WithdrawRequest> Withdraw(string coin, string address, decimal amount, string? withdrawOrderId,
		string? network, string? addressTag, bool? transactionFeeFlag, string? name, int? walletType);

	Task<List<Deposit>> GetDepositHistory(string? coin, int? status, long? startTime, long? endTime,
		int? offset, int? limit);

	Task<List<Withdraw>> GetWithdrawHistory(string? coin, int? status, long? startTime, long? endTime, int? offset,
		int? limit);

	Task<Address> GetDepositAddress(string coin, string? network);
	Task<AccountStatus> GetAccountStatus();
	Task<AccountApiStatus> GetAccountApiTradingStatus();
	Task<DustLog> GetDustLog(long? startTime, long? endTime);
	Task<ConvertableAsset> GetBnbConvertableAssets();
	Task<DustTransfer> DustTransfer(string asset);
	Task<DividendRecord> GetAssetDividendRecords(string? asset, long? startTime, long? endTime, int? limit);
	Task<AssetDetail> GetAssetDetail(string? asset);
	Task<List<TradeFee>> GetTradeFee(string? symbol);

	Task<UserUniversalTransfer> UserUniversalTransfer(string type, string asset, decimal amount, string? fromSymbol,
		string? toSymbol);

	Task<UserUniversalTransferHistory> GetUserUniversalTransferHistory(string type, long? startTime, long? endTime,
		int? current, int? size, string? fromSymbol, string? toSymbol);

	Task<List<UserAsset>> GetFundingWallet(string? asset, string? needBtcValuation);
	Task<List<UserAsset>> GetUserAssets(string? asset, string? needBtcValuation);
	Task<ApiKeyPermission> GetApiKeyPermissions();
}