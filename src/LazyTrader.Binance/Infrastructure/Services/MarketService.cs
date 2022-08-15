namespace LazyTrader.Binance.Infrastructure.Services;

internal class MarketService : IMarketService
{
	private readonly ILogger<MarketService> _logger;
	private readonly IRequestService _requestService;
	private readonly IStatusService _statusService;

	public MarketService(ILogger<MarketService> logger, IRequestService requestService, IStatusService statusService)
	{
		_logger = logger;
		_requestService = requestService;
		_statusService = statusService;
	}

	public async Task<ExchangeInfo> GetExchangeInfo(string? symbol, List<string>? symbolsList)
	{
		_logger.LogInformation(">> GetExchangeInfo");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentsOnlyOneCanBeUsed(symbol, symbolsList);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);

		if (symbol != null)
			queryValues.Add("symbol", symbol);
		if (symbolsList != null)
			queryValues.Add("symbolsList", $"[\"{string.Join("\",\"", symbolsList)}\"]");

		var result = await _requestService.Get<ExchangeInfo>($"/api/v3/exchangeInfo", queryValues);

		_logger.LogInformation("<< GetExchangeInfo");
		return result;
	}

	public async Task<OrderBook> GetOrderBook(string symbol, int? limit = null)
	{
		_logger.LogInformation(">> GetOrderBook");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("symbol", symbol);

		if (limit != null)
		{
			ValidationUtils.ArgumentInsideRangeArray((int)limit, nameof(limit),
				new[] { 5, 10, 20, 50, 100, 500, 1000, 5000 });
			queryValues.Add("limit", limit.ToString());
		}

		var result = await _requestService.Get<OrderBook>($"/api/v3/depth", queryValues);

		_logger.LogInformation("<< GetOrderBook");
		return result;
	}

	public async Task<List<Trade>> GetRecentTrades(string symbol, int? limit = null)
	{
		_logger.LogInformation(">> GetRecentTrades");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));
		ValidationUtils.ArgumentBelowLimit(limit, nameof(limit), 5000);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("symbol", symbol);

		if (limit != null) queryValues.Add("limit", limit.ToString());

		var result = await _requestService.Get<List<Trade>>($"/api/v3/trades", queryValues);

		_logger.LogInformation("<< GetRecentTrades");
		return result;
	}

	public async Task<List<Trade>> GetHistoricalTrades(string symbol, long? fromId, int? limit)
	{
		_logger.LogInformation(">> GetHistoricalTrades");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));
		ValidationUtils.ArgumentBelowLimit(limit, nameof(limit), 1000);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("symbol", symbol);

		if (limit != null) queryValues.Add("limit", limit.ToString());
		if (fromId != null) queryValues.Add("fromId", fromId.ToString());

		var result = await _requestService.Get<List<Trade>>($"/api/v3/historicalTrades", queryValues);

		_logger.LogInformation("<< GetHistoricalTrades");
		return result;
	}

	public async Task<List<AggregateTrade>> GetAggregatedTrades(string symbol, long? fromId, long? startTime,
		long? endTime, int? limit)
	{
		_logger.LogInformation(">> GetAggregatedTrades");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));
		ValidationUtils.ArgumentBelowLimit(limit, nameof(limit), 1000);
		//TODO: If startTime and endTime are sent, time between startTime and endTime must be less than 1 hour.
		//ValidationUtils.BetweenTimestampsLessThan(symbol, nameof(symbol));

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("symbol", symbol);

		if (limit != null) queryValues.Add("limit", limit.ToString());
		if (fromId != null) queryValues.Add("fromId", fromId.ToString());
		if (startTime != null) queryValues.Add("startTime", startTime.ToString());
		if (endTime != null) queryValues.Add("endTime", endTime.ToString());

		var result = await _requestService.Get<List<AggregateTrade>>($"/api/v3/aggTrades", queryValues);

		_logger.LogInformation("<< GetAggregatedTrades");
		return result;
	}

	public async Task<List<List<object>>> GetCandlestickData(string symbol, string interval, long? startTime,
		long? endTime, int? limit)
	{
		_logger.LogInformation(">> GetCandlestickData");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));
		ValidationUtils.ArgumentBelowLimit(limit, nameof(limit), 1000);

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("symbol", symbol);
		queryValues.Add("interval", interval);

		if (limit != null) queryValues.Add("limit", limit.ToString());
		if (startTime != null) queryValues.Add("startTime", startTime.ToString());
		if (endTime != null) queryValues.Add("endTime", endTime.ToString());

		var result = await _requestService.Get<List<List<object>>>($"/api/v3/klines", queryValues);

		_logger.LogInformation("<< GetCandlestickData");
		return result;
	}

	public async Task<AveragePrice> CurrentAveragePrice(string symbol)
	{
		_logger.LogInformation(">> CurrentAveragePrice");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("symbol", symbol);

		var result = await _requestService.Get<AveragePrice>($"/api/v3/avgPrice", queryValues);

		_logger.LogInformation("<< CurrentAveragePrice");
		return result;
	}

	public async Task<TickerPrice> GetPriceChangeStatisticsTicker(string symbol)
	{
		_logger.LogInformation(">> GetPriceChangeStatisticsTicker");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("symbol", symbol);

		var result = await _requestService.Get<TickerPrice>($"/api/v3/ticker/24hr", queryValues);

		_logger.LogInformation("<< GetPriceChangeStatisticsTicker");
		return result;
	}

	public async Task<List<TickerPrice>> GetAllPriceChangeStatisticsTicker()
	{
		_logger.LogInformation(">> GetAllPriceChangeStatisticsTicker");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var result = await _requestService.Get<List<TickerPrice>>($"/api/v3/ticker/24hr");

		_logger.LogInformation("<< GetAllPriceChangeStatisticsTicker");
		return result;
	}

	public async Task<LatestPrice> GetSymbolPriceTicker(string symbol)
	{
		_logger.LogInformation(">> GetSymbolPriceTicker");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("symbol", symbol);

		var result = await _requestService.Get<LatestPrice>($"/api/v3/ticker/price", queryValues);

		_logger.LogInformation("<< GetSymbolPriceTicker");
		return result;
	}

	public async Task<List<LatestPrice>> GetAllSymbolsPriceTicker()
	{
		_logger.LogInformation(">> GetAllSymbolsPriceTicker");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var result = await _requestService.Get<List<LatestPrice>>($"/api/v3/ticker/price");

		_logger.LogInformation("<< GetAllSymbolsPriceTicker");
		return result;
	}

	public async Task<OrderBookTicker> GetSymbolOrderBookTicker(string symbol)
	{
		_logger.LogInformation(">> GetSymbolOrderBookTicker");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
		ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));

		var queryValues = HttpUtility.ParseQueryString(string.Empty);
		queryValues.Add("symbol", symbol);

		var result = await _requestService.Get<OrderBookTicker>($"/api/v3/ticker/bookTicker", queryValues);

		_logger.LogInformation("<< GetSymbolOrderBookTicker");
		return result;
	}

	public async Task<List<OrderBookTicker>> GetAllSymbolOrderBookTicker()
	{
		_logger.LogInformation(">> GetAllSymbolOrderBookTicker");

		ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

		var result = await _requestService.Get<List<OrderBookTicker>>($"/api/v3/ticker/bookTicker");

		_logger.LogInformation("<< GetAllSymbolOrderBookTicker");
		return result;
	}
}