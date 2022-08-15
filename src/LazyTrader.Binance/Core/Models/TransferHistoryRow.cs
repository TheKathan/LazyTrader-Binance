namespace LazyTrader.Binance.Core.Models;

public record TransferHistoryRow(
	[property:JsonProperty("asset")] string Asset,
	[property:JsonProperty("amount")] string Amount,
	[property:JsonProperty("type")] string Type,
	[property:JsonProperty("status")] string Status,
	[property:JsonProperty("tranId")] long TranId,
	[property:JsonProperty("timestamp")] long Timestamp
); 