namespace LazyTrader.Binance.Core.Models;

public record NftTransaction(
	[property: JsonProperty("orderNo")] string OrderNo,
	[property: JsonProperty("tokens")] IReadOnlyList<NftToken> Tokens,
	[property: JsonProperty("tradeTime")] long TradeTime,
	[property: JsonProperty("tradeAmount")] string TradeAmount,
	[property: JsonProperty("tradeCurrency")] string TradeCurrency
);