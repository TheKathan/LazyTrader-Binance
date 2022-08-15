namespace LazyTrader.Binance.Core.Models;

public record Withdraw(
	[property:JsonProperty("address")] string Address,
	[property:JsonProperty("amount")] string Amount,
	[property:JsonProperty("applyTime")] string ApplyTime,
	[property:JsonProperty("coin")] string Coin,
	[property:JsonProperty("id")] string Id,
	[property:JsonProperty("withdrawOrderId")] string WithdrawOrderId,
	[property:JsonProperty("network")] string Network,
	[property:JsonProperty("transferType")] int TransferType,
	[property:JsonProperty("status")] int Status,
	[property:JsonProperty("transactionFee")] string TransactionFee,
	[property:JsonProperty("confirmNo")] int ConfirmNo,
	[property:JsonProperty("info")] string Info,
	[property:JsonProperty("txId")] string TxId
);