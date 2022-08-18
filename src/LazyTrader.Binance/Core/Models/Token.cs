namespace LazyTrader.Binance.Core.Models;

public record NftToken(
	[property: JsonProperty("network")] string Network,
	[property: JsonProperty("tokenId")] string TokenId,
	[property: JsonProperty("contractAddress")] string ContractAddress
);