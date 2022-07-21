namespace LazyTrader.Binance.Core.Models;

public record AveragePrice(
    [property:JsonProperty("mins")] string Mins,
    [property:JsonProperty("price")] string Price
);