namespace LazyTrader.Binance.Core.Models;

public record UserUniversalTransferHistory(
	[property:JsonProperty("total")] int Total,
	[property:JsonProperty("rows")] IReadOnlyList<TransferHistoryRow> Rows
); 