namespace LazyTrader.Binance.Core.Models;

public record DividendRecordRow(
	[property:JsonProperty("id")] long Id,
	[property:JsonProperty("amount")] string Amount,
	[property:JsonProperty("asset")] string Asset,
	[property:JsonProperty("divTime")] long DivTime,
	[property:JsonProperty("enInfo")] string EnInfo,
	[property:JsonProperty("tranId")] long TranId
); 