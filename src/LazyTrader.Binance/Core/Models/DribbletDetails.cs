namespace LazyTrader.Binance.Core.Models;

public record DribbletDetails(
	[property:JsonProperty("transId")] long TransId,
	[property:JsonProperty("serviceChargeAmount")] string ServiceChargeAmount,
	[property:JsonProperty("amount")] string Amount,
	[property:JsonProperty("operateTime")] long OperateTime,
	[property:JsonProperty("transferedAmount")] string TransferredAmount,
	[property:JsonProperty("fromAsset")] string FromAsset
	
); 