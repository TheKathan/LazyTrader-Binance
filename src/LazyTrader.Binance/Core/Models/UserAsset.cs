namespace LazyTrader.Binance.Core.Models;

public record UserAsset(
	[property:JsonProperty("asset")] string Asset,
	[property:JsonProperty("free")] string Free,
	[property:JsonProperty("locked")] string Locked,
	[property:JsonProperty("freeze")] string Freeze,
	[property:JsonProperty("withdrawing")] string Withdrawing,
	[property:JsonProperty("ipoable")] string? Ipoable,
	[property:JsonProperty("btcValuation")] string BtcValuation
	
);