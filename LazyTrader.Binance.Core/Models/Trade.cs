namespace LazyTrader.Binance.Core.Models;

public record Trade(
    [property:JsonProperty("id")] long Id,
    [property:JsonProperty("price")] string Price,
    [property:JsonProperty("qty")] string Quantity,
    [property:JsonProperty("quoteQty")] string QuoteQuantity,
    [property:JsonProperty("time")] long Time,
    [property:JsonProperty("isBuyerMaker")] bool IsBuyerMaker,
    [property:JsonProperty("isBestMatch")] bool IsBestMatch
);