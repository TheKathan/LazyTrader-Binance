namespace LazyTrader.Binance.Core.Models;

public record NftDeposit(
	[property: JsonProperty("network")] string Network,
	[property: JsonProperty("txID")] string? TxId,
	[property: JsonProperty("contractAdrress")] string ContractAddress,
	[property: JsonProperty("tokenId")] string TokenId,
	[property: JsonProperty("timestamp")] long Timestamp
);