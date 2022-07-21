namespace LazyTrader.Binance.Core.Models;

public record AggregateTrade(
    [property:JsonProperty("a")] long AggregateTradeId,
    [property:JsonProperty("p")] string Price,
    [property:JsonProperty("q")] string Quantity,
    [property:JsonProperty("f")] long FirstTradeId,
    [property:JsonProperty("l")] string LastTradeId,
    [property:JsonProperty("T")] long Timestamp,
    [property:JsonProperty("m")] bool IsBuyerMaker,
    [property:JsonProperty("M")] bool IsBestMatch
);