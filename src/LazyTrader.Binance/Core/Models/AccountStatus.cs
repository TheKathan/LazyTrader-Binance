namespace LazyTrader.Binance.Core.Models;

public record AccountStatus(
	[property:JsonProperty("data")] string Data
);