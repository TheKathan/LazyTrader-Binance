namespace LazyTrader.Binance.Core.Models;

public record AssetDetail(
	[property:JsonProperty("CTR")] Ctr Ctr,
	[property:JsonProperty("SKY")] Sky Sky
);