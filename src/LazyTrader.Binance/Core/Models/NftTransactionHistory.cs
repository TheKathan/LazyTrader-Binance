namespace LazyTrader.Binance.Core.Models;

public record NftTransactionHistory(
	[property: JsonProperty("total")] int Total,
	[property: JsonProperty("list")] IReadOnlyList<NftTransaction> Transactions
);