namespace LazyTrader.Binance.Core.Models;

public record Fill(
    [property:JsonProperty("price")] string Price,
    [property:JsonProperty("qty")] string Qty,
    [property:JsonProperty("commission")] string Commission,
    [property:JsonProperty("commissionAsset")] string CommissionAsset
);