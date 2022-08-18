namespace LazyTrader.Binance.Core.Services;

public interface INftService
{
    Task<NftTransactionHistory> GetTransactionHistory(int orderType, long? startTime, long? endTime, int? limit, int? page);
    Task<NftDepositHistory> GetDepositHistory(long? startTime, long? endTime, int? limit, int? page);
    Task<NftWithdrawHistory> GetWithdrawHistory(long? startTime, long? endTime, int? limit, int? page);
    Task<NftAsset> GetTokens(int? limit, int? page);
}