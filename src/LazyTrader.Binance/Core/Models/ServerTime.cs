namespace LazyTrader.Binance.Core.Models;

public record ServerTime(
    [property:JsonProperty("serverTime")] string? Timestamp
);
