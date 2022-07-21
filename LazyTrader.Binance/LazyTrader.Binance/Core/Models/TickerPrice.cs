namespace LazyTrader.Binance.Core.Models;

public record TickerPrice(
    [property:JsonProperty("symbol")] string Symbol,
    [property:JsonProperty("priceChange")] string PriceChange,
    [property:JsonProperty("priceChangePercent")] string PriceChangePercent,
    [property:JsonProperty("weightedAvgPrice")] string WeightedAvgPrice,
    [property:JsonProperty("prevClosePrice")] string PrevClosePrice,
    [property:JsonProperty("lastPrice")] string LastPrice,
    [property:JsonProperty("lastQty")] string LastQty,
    [property:JsonProperty("bidPrice")] string BidPrice,
    [property:JsonProperty("bidQty")] string BidQty,
    [property:JsonProperty("askPrice")] string AskPrice,
    [property:JsonProperty("askQty")] string AskQty,
    [property:JsonProperty("openPrice")] string OpenPrice,
    [property:JsonProperty("highPrice")] string HighPrice,
    [property:JsonProperty("lowPrice")] string LowPrice,
    [property:JsonProperty("volume")] string Volume,
    [property:JsonProperty("quoteVolume")] string QuoteVolume,
    [property:JsonProperty("openTime")] long OpenTime,
    [property:JsonProperty("closeTime")] long CloseTime,
    [property:JsonProperty("firstId")] int FirstId,
    [property:JsonProperty("lastId")] long LastId,
    [property:JsonProperty("count")] long Count
);