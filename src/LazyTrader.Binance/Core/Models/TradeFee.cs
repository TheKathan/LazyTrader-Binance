namespace LazyTrader.Binance.Core.Models;

public record TradeFee(
	[property:JsonProperty("symbol")] string Symbol,
	[property:JsonProperty("makerCommission")] string MakerCommission,
	[property:JsonProperty("takerCommission")] string TakerCommission
);