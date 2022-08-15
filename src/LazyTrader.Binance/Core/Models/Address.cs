namespace LazyTrader.Binance.Core.Models;

public record Address(
    [property:JsonProperty("address")] string? AddressCode,
    [property:JsonProperty("coin")] string? Coin,
    [property:JsonProperty("tag")] string? Tag,
    [property:JsonProperty("url")] string? Url
);