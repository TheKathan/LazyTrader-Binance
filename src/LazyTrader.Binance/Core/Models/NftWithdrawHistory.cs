namespace LazyTrader.Binance.Core.Models;

public record NftWithdrawHistory(
	[property: JsonProperty("total")] int Total,
	[property: JsonProperty("list")] IReadOnlyList<NftWithdraw> Withdraws
);
