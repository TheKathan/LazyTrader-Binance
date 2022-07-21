namespace LazyTrader.Binance.Core.Models;

public record LatestPrice(
    [property:JsonProperty("symbol")] string Symbol,
    [property:JsonProperty("price")] string Price
);