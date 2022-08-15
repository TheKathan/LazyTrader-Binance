namespace LazyTrader.Binance.Core.Models;

public record Deposit(
	[property:JsonProperty("amount")] string Amount,
	[property:JsonProperty("coin")] string Coin,
	[property:JsonProperty("network")] string Network,
	[property:JsonProperty("status")] int Status,
	[property:JsonProperty("address")] string Address,
	[property:JsonProperty("addressTag")] string AddressTag,
	[property:JsonProperty("txId")] string TxId,
	[property:JsonProperty("insertTime")] long InsertTime,
	[property:JsonProperty("transferType")] int TransferType,
	[property:JsonProperty("unlockConfirm")] string UnlockConfirm,
	[property:JsonProperty("confirmTimes")] string ConfirmTimes
);