namespace LazyTrader.Binance.Core.Models;

public record CoinInformation(
	[property:JsonProperty("coin")] string Coin,
	[property:JsonProperty("depositAllEnable")] bool DepositAllEnable,
	[property:JsonProperty("free")] string Free,
	[property:JsonProperty("freeze")] string Freeze,
	[property:JsonProperty("ipoable")] string Ipoable,
	[property:JsonProperty("ipoing")] string Ipoing,
	[property:JsonProperty("isLegalMoney")] bool IsLegalMoney,
	[property:JsonProperty("locked")] string Locked,
	[property:JsonProperty("name")] string Name,
	[property:JsonProperty("networkList")] IReadOnlyList<Network> Networks,
	[property:JsonProperty("storage")] string Storage,
	[property:JsonProperty("trading")] bool Trading,
	[property:JsonProperty("withdrawAllEnable")] bool WithdrawAllEnable,
	[property:JsonProperty("withdrawing")] string Withdrawing
);