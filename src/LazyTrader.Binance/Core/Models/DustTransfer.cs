namespace LazyTrader.Binance.Core.Models;

public record DustTransfer(
	[property:JsonProperty("totalServiceCharge")] string TotalServiceCharge,
	[property:JsonProperty("totalTransfered")] string TotalTransferred,
	[property:JsonProperty("userAssetDribblets")] IReadOnlyList<TransferResult> TransferResults
); 