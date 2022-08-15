namespace LazyTrader.Binance.Core.Models;

public record TransferResult(
	[property:JsonProperty("amount")] string Amount,
	[property:JsonProperty("fromAsset")] string FromAsset,
	[property:JsonProperty("operateTime")] long OperateTime,
	[property:JsonProperty("serviceChargeAmount")] string ServiceChargeAmount,
	[property:JsonProperty("tranId")] long TranId,
	[property:JsonProperty("transferedAmount")] string TransferredAmount
); 