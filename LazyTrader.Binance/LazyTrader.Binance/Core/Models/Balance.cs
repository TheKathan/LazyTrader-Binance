namespace LazyTrader.Binance.Core.Models;

public record Balance(
    [property:JsonProperty("asset")] string? Asset,
    [property:JsonProperty("free")] string? Free,
    [property:JsonProperty("locked")]string? Locked
);