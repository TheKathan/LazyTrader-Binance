namespace LazyTrader.Binance.Core.Models;

public record DustLog(
	[property:JsonProperty("total")] int Total,
	[property:JsonProperty("userAssetDribblets")] IReadOnlyList<UserAssetDribblet> UserAssetDribblets
); 