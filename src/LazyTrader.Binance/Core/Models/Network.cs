namespace LazyTrader.Binance.Core.Models;

public record Network(
	[property:JsonProperty("addressRegex")] string AddressRegex,
	[property:JsonProperty("coin")] string Coin,
	[property:JsonProperty("depositDesc")] string DepositDesc,
	[property:JsonProperty("depositEnable")] bool DepositEnable,
	[property:JsonProperty("isDefault")] bool IsDefault,
	[property:JsonProperty("memoRegex")] string MemoRegex,
	[property:JsonProperty("minConfirm")] int MinConfirm,
	[property:JsonProperty("name")] string Name,
	[property:JsonProperty("network")] string NetworkCode,
	[property:JsonProperty("resetAddressStatus")] bool ResetAddressStatus,
	[property:JsonProperty("specialTips")] string SpecialTips,
	[property:JsonProperty("unLockConfirm")] int UnLockConfirm,
	[property:JsonProperty("withdrawDesc")] string WithdrawDesc,
	[property:JsonProperty("withdrawEnable")] bool WithdrawEnable,
	[property:JsonProperty("withdrawFee")] string WithdrawFee,
	[property:JsonProperty("withdrawIntegerMultiple")] string WithdrawIntegerMultiple,
	[property:JsonProperty("withdrawMax")] string WithdrawMax,
	[property:JsonProperty("withdrawMin")] string WithdrawMin,
	[property:JsonProperty("sameAddress")] bool SameAddress,
	[property:JsonProperty("estimatedArrivalTime")] int EstimatedArrivalTime,
	[property:JsonProperty("busy")] bool Busy
);