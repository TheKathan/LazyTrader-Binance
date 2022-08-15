namespace LazyTrader.Binance.Core.Models;

public record Data(
	[property:JsonProperty("balances")] IReadOnlyList<Balance> Balances,
	[property:JsonProperty("totalAssetOfBtc")] string TotalAssetOfBtc
);