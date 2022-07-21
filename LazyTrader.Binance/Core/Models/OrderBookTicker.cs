namespace LazyTrader.Binance.Core.Models;

public record OrderBookTicker(
    [property:JsonProperty("symbol")] string Symbol,
    [property:JsonProperty("bidPrice")] string BidPrice,
    [property:JsonProperty("bidQty")] string BidQty,
    [property:JsonProperty("askPrice")] string AskPrice,
    [property:JsonProperty("askQty")] string AskQty
);