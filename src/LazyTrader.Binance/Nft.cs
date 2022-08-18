namespace LazyTrader.Binance;

public class Nft
{
	private readonly ILogger<Nft> _logger;
	private readonly INftService _nftService;

	public Nft(ILogger<Nft> logger, INftService nftService)
	{
		_logger = logger;
		_nftService = nftService;
	}

	public async Task<NftTransactionHistory> GetTransactionHistory(int orderType, long? startTime, long? endTime,
		int? limit, int? page)
	{
		_logger.LogInformation("> GetTransactionHistory");

		var result = await _nftService.GetTransactionHistory(orderType, startTime, endTime, limit, page);

		_logger.LogInformation("< GetTransactionHistory");
		return result;
	}
	
	public async Task<NftDepositHistory> GetDepositHistory(long? startTime, long? endTime, int? limit, int? page)
	{
		_logger.LogInformation("> GetDepositHistory");

		var result = await _nftService.GetDepositHistory(startTime, endTime, limit, page);

		_logger.LogInformation("< GetDepositHistory");
		return result;
	}

	public async Task<NftWithdrawHistory> GetWithdrawHistory(long? startTime, long? endTime, int? limit, int? page)
	{
		_logger.LogInformation("> GetWithdrawHistory");

		var result = await _nftService.GetWithdrawHistory(startTime, endTime, limit, page);

		_logger.LogInformation("< GetWithdrawHistory");
		return result;
	}
	
	public async Task<NftAsset> GetTokens(int? limit, int? page)
	{
		_logger.LogInformation("> GetTokens");

		var result = await _nftService.GetTokens(limit, page);

		_logger.LogInformation("< GetTokens");
		return result;
	}
}