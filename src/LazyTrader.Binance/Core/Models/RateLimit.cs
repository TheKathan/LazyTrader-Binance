namespace LazyTrader.Binance.Core.Models;

public record RateLimit(
    [property:JsonProperty("rateLimitType")] string Type,
    [property:JsonProperty("interval")] string Interval,
    [property:JsonProperty("intervalNum")] int IntervalNum,
    [property:JsonProperty("limit")] int Limit
);