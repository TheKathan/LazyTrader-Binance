namespace LazyTrader.Binance.Core.Models;

public record Symbol(
    [property:JsonProperty("symbol")] string Name,
    [property:JsonProperty("status")] string Status,
    [property:JsonProperty("baseAsset")] string BaseAsset,
    [property:JsonProperty("baseAssetPrecision")] int BaseAssetPrecision,
    [property:JsonProperty("quoteAsset")] string QuoteAsset,
    [property:JsonProperty("quotePrecision")] int QuotePrecision,
    [property:JsonProperty("quoteAssetPrecision")] int QuoteAssetPrecision,
    [property:JsonProperty("orderTypes")] IReadOnlyList<string> OrderTypes,
    [property:JsonProperty("icebergAllowed")] bool IcebergAllowed,
    [property:JsonProperty("ocoAllowed")] bool OcoAllowed,
    [property:JsonProperty("isSpotTradingAllowed")] bool IsSpotTradingAllowed,
    [property:JsonProperty("isMarginTradingAllowed")] bool IsMarginTradingAllowed,
    [property:JsonProperty("filters")] IReadOnlyList<Filter> Filters,
    [property:JsonProperty("permissions")] IReadOnlyList<string> Permissions
);