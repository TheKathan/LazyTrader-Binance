namespace LazyTrader.Binance.Core.Models;

public record Ctr(
	[property:JsonProperty("minWithdrawAmount")] string MinWithdrawAmount,
	[property:JsonProperty("depositStatus")] bool DepositStatus,
	[property:JsonProperty("withdrawFee")] double WithdrawFee,
	[property:JsonProperty("withdrawStatus")] bool WithdrawStatus,
	[property:JsonProperty("depositTip")] string DepositTip
);