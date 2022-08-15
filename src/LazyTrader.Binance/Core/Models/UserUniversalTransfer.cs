namespace LazyTrader.Binance.Core.Models;

public record UserUniversalTransfer(
	[property:JsonProperty("tranId")] long TranId
);