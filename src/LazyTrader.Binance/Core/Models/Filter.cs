namespace LazyTrader.Binance.Core.Models;

public record Filter(
    [property:JsonProperty("filterType")] string Type,
    [property:JsonProperty("minNotional")] string MinNotional,
    [property:JsonProperty("applyToMarket")] bool ApplyToMarket,
    [property:JsonProperty("avgPriceMins")] int AvgPriceMins
);