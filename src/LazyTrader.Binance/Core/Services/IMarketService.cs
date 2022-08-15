namespace LazyTrader.Binance.Core.Services;

public interface IMarketService
{
    Task<ExchangeInfo> GetExchangeInfo(string? symbol, List<string>? symbolsList);
    Task<OrderBook> GetOrderBook(string symbol, int? limit);
    Task<List<Trade>> GetRecentTrades(string symbol, int? limit);
    Task<List<Trade>> GetHistoricalTrades(string symbol, long? fromId,int? limit);
    Task<List<AggregateTrade>> GetAggregatedTrades(string symbol, long? fromId, long? startTime, long? endTime,
        int? limit);
    Task<List<List<object>>> GetCandlestickData(string symbol, string interval, long? startTime, long? endTime, int? limit);
    Task<AveragePrice> CurrentAveragePrice(string symbol);
    Task<TickerPrice> GetPriceChangeStatisticsTicker(string symbol);
    Task<List<TickerPrice>> GetAllPriceChangeStatisticsTicker();
    Task<LatestPrice> GetSymbolPriceTicker(string symbol);
    Task<List<LatestPrice>> GetAllSymbolsPriceTicker();
    Task<OrderBookTicker> GetSymbolOrderBookTicker(string symbol);
    Task<List<OrderBookTicker>> GetAllSymbolOrderBookTicker();
}