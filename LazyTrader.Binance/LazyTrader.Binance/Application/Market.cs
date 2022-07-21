namespace LazyTrader.Binance.Application;

public class Market
{
    private readonly ILogger<Market> _logger;
    private readonly IMarketService _marketService;

    public Market(ILogger<Market> logger, IMarketService marketService)
    {
        _logger = logger;
        _marketService = marketService;
        var temp = new MarketService(null, null, null);
    }
    
    public async Task<ExchangeInfo> GetExchangeInfo(string? symbol, List<string>? symbolsList)
    {
        _logger.LogInformation("> GetExchangeInfo");

        var result = await _marketService.GetExchangeInfo(symbol, symbolsList);
        
        _logger.LogInformation("< GetExchangeInfo");
        return result;
    }

    public async Task<OrderBook> GetOrderBook(string symbol, int? limit = null)
    {
        _logger.LogInformation("> GetOrderBook");

        var result = await _marketService.GetOrderBook(symbol, limit);

        _logger.LogInformation("< GetOrderBook");
        return result;
    }

    public async Task<List<Trade>> GetRecentTrades(string symbol, int? limit)
    {
        _logger.LogInformation("> GetRecentTrades");

        var result = await _marketService.GetRecentTrades(symbol, limit);
        
        _logger.LogInformation("< GetRecentTrades");
        return result;
    }

    public async Task<List<Trade>> GetHistoricalTrades(string symbol, long? fromId, int? limit)
    {
        _logger.LogInformation("> GetHistoricalTrades");

        var result = await _marketService.GetHistoricalTrades(symbol, fromId, limit);
        
        _logger.LogInformation("< GetHistoricalTrades");
        return result;
    }

    public async Task<List<AggregateTrade>> GetAggregatedTrades(string symbol, long? fromId, long? startTime, long? endTime, int? limit)
    {
        _logger.LogInformation("> GetAggregatedTrades");

        var result = await _marketService.GetAggregatedTrades(symbol, fromId, startTime, endTime, limit);

        _logger.LogInformation("< GetAggregatedTrades");
        return result;
    }

    public async Task<List<List<object>>> GetCandlestickData(string symbol, string interval, long? startTime, long? endTime, int? limit)
    {
        _logger.LogInformation("> GetCandlestickData");

        var result = await _marketService.GetCandlestickData(symbol, interval, startTime, endTime, limit);
        
        _logger.LogInformation("< GetCandlestickData");
        return result;
    }

    public async Task<AveragePrice> CurrentAveragePrice(string symbol)
    {
        _logger.LogInformation("> CurrentAveragePrice");

        var result = await _marketService.CurrentAveragePrice(symbol);

        _logger.LogInformation("< CurrentAveragePrice");
        return result;
    }

    public async Task<TickerPrice> GetPriceChangeStatisticsTicker(string symbol)
    {
        _logger.LogInformation("> GetPriceChangeStatisticsTicker");

        var result = await _marketService.GetPriceChangeStatisticsTicker(symbol);
        
        _logger.LogInformation("< GetPriceChangeStatisticsTicker");
        return result;
    }

    public async Task<List<TickerPrice>> GetAllPriceChangeStatisticsTicker()
    {
        _logger.LogInformation("> GetAllPriceChangeStatisticsTicker");

        var result = await _marketService.GetAllPriceChangeStatisticsTicker();
        
        _logger.LogInformation("< GetAllPriceChangeStatisticsTicker");
        return result;
    }

    public async Task<LatestPrice> GetSymbolPriceTicker(string symbol)
    {
        _logger.LogInformation("> GetSymbolPriceTicker");

        var result = await _marketService.GetSymbolPriceTicker(symbol);
        
        _logger.LogInformation("< GetSymbolPriceTicker");
        return result;
    }

    public async Task<List<LatestPrice>> GetAllSymbolsPriceTicker()
    {
        _logger.LogInformation("> GetAllSymbolsPriceTicker");

        var result = await _marketService.GetAllSymbolsPriceTicker();
        
        _logger.LogInformation("< GetAllSymbolsPriceTicker");
        return result;
    }

    public async Task<OrderBookTicker> GetSymbolOrderBookTicker(string symbol)
    {
        _logger.LogInformation("> GetSymbolOrderBookTicker");

        var result = await _marketService.GetSymbolOrderBookTicker(symbol);
        
        _logger.LogInformation("< GetSymbolOrderBookTicker");
        return result;
    }
    
    public async Task<List<OrderBookTicker>> GetAllSymbolOrderBookTicker()
    {
        _logger.LogInformation("> GetAllSymbolOrderBookTicker");

        var result = await _marketService.GetAllSymbolOrderBookTicker();
        
        _logger.LogInformation("< GetAllSymbolOrderBookTicker");
        return result;
    }
}