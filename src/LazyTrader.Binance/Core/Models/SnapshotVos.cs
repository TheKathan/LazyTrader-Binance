namespace LazyTrader.Binance.Core.Models;

public record SnapshotVos(
	[property:JsonProperty("data")] Data Data,
	[property:JsonProperty("type")] string Type,
	[property:JsonProperty("updateTime")] long UpdateTime
);