namespace LazyTrader.Binance.Core.Models;

public record UserAssetDribblet(
	[property:JsonProperty("operateTime")] long OperateTime,
	[property:JsonProperty("totalTransferedAmount")] string TotalTransferredAmount,
	[property:JsonProperty("totalServiceChargeAmount")] string TotalServiceChargeAmount,
	[property:JsonProperty("transId")] long TransId,
	[property:JsonProperty("userAssetDribblets")] IReadOnlyList<DribbletDetails> DribbletDetails
); 