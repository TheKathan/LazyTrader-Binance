namespace LazyTrader.Binance.Core.Models;

public record WithdrawRequest(
	[property:JsonProperty("id")] string Id
);