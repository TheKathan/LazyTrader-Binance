namespace LazyTrader.Binance.Core.Models;

public record NftDepositHistory(
	[property: JsonProperty("total")] int Total,
	[property: JsonProperty("list")] IReadOnlyList<NftDeposit> Deposits
);