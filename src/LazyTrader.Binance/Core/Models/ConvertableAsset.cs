namespace LazyTrader.Binance.Core.Models;

public record ConvertableAsset(
	[property:JsonProperty("details")] string Details,
	[property:JsonProperty("totalTransferBtc")] string TotalTransferBtc,
	[property:JsonProperty("totalTransferBNB")] string TotalTransferBnb,
	[property:JsonProperty("dribbletPercentage")] string DribbletPercentage,
	[property:JsonProperty("userAssetDribblets")] IReadOnlyList<ConvertableAssetDetails> DribbletDetails
); 