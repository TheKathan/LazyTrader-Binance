namespace LazyTrader.Binance.Core.Models;

public record AccountApiStatus(
	[property:JsonProperty("data")] AccountData Data
); 