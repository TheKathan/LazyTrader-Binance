namespace LazyTrader.Binance.Core.Models;

public record Snapshot(
	[property:JsonProperty("code")] int Code,
	[property:JsonProperty("msg")] string Message,
	[property:JsonProperty("snapshotVos")] IReadOnlyList<SnapshotVos> Networks
);