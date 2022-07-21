namespace LazyTrader.Binance.Core.Models;

public record Account(
    [property:JsonProperty("makerCommission")] int MakerCommission,
    [property:JsonProperty("takerCommission")] int TakerCommission,
    [property:JsonProperty("buyerCommission")] int BuyerCommission,
    [property:JsonProperty("sellerCommission")] int SellerCommission,
    [property:JsonProperty("canTrade")] bool CanTrade,
    [property:JsonProperty("canWithdraw")] bool CanWithdraw,
    [property:JsonProperty("canDeposit")] bool CanDeposit,
    [property:JsonProperty("updateTime")] long UpdateTime,
    [property:JsonProperty("accountType")] string? AccountType,
    [property:JsonProperty("balances")] List<Balance> Balances,
    [property:JsonProperty("permissions")] List<string> Permissions
);