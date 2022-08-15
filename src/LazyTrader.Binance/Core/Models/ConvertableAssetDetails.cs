namespace LazyTrader.Binance.Core.Models;

public record ConvertableAssetDetails(
	[property:JsonProperty("asset")] string Asset,
	[property:JsonProperty("assetFullName")] string AssetFullName,
	[property:JsonProperty("amountFree")] string AmountFree,
	[property:JsonProperty("toBTC")] string ToBtc,
	[property:JsonProperty("toBNB")] string ToBnb,
	[property:JsonProperty("toBNBOffExchange")] string ToBnbOffExchange,
	[property:JsonProperty("exchange")] string Exchange
); 