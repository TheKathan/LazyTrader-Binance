namespace LazyTrader.Binance.Core.Models;

public record ExchangeInfo(
    [property:JsonProperty("timezone")] string Timezone,
    [property:JsonProperty("serverTime")] long ServerTime,
    [property:JsonProperty("rateLimits")] IReadOnlyList<RateLimit> RateLimits,
    [property:JsonProperty("exchangeFilters")] IReadOnlyList<object> ExchangeFilters,
    [property:JsonProperty("symbols")] IReadOnlyList<Symbol> Symbols
);