namespace LazyTrader.Binance.Core.Models;

public record OrderCountUsage(
    [property:JsonProperty("rateLimitType")] string RateLimitType,
    [property:JsonProperty("interval")] string Interval,
    [property:JsonProperty("intervalNum")] int IntervalNum,
    [property:JsonProperty("limit")] int Limit,
    [property:JsonProperty("count")] int Count
);