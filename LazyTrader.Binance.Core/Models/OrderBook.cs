namespace LazyTrader.Binance.Core.Models;

public record OrderBook(
    [property:JsonProperty("lastUpdateId")] long LastUpdateId,
    [property:JsonProperty("bids")] IReadOnlyList<IReadOnlyList<string>> Bids,
    [property:JsonProperty("asks")] IReadOnlyList<IReadOnlyList<string>> Asks
);