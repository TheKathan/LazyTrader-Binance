namespace LazyTrader.Binance.Core.Models;

public record Order(
    [property:JsonProperty("symbol")] string Symbol,
    [property:JsonProperty("orderId")] int OrderId,
    [property:JsonProperty("clientOrderId")] string ClientOrderId,
    [property:JsonProperty("orderListId")] int OrderListId,
    [property:JsonProperty("transactTime")] long TransactTime,
    [property:JsonProperty("price")] string Price,
    [property:JsonProperty("origQty")] string OrigQty,
    [property:JsonProperty("executedQty")] string ExecutedQty,
    [property:JsonProperty("cummulativeQuoteQty")] string CummulativeQuoteQty,
    [property:JsonProperty("status")] string Status,
    [property:JsonProperty("timeInForce")] string TimeInForce,
    [property:JsonProperty("type")] string Type,
    [property:JsonProperty("side")] string Side,
    [property:JsonProperty("stopPrice")] string StopPrice,
    [property:JsonProperty("icebergQty")] string IcebergQty,
    [property:JsonProperty("time")] long Time,
    [property:JsonProperty("updateTime")] long UpdateTime,
    [property:JsonProperty("isWorking")] bool IsWorking,
    [property:JsonProperty("origQuoteOrderQty")] string OrigQuoteOrderQty,
    [property:JsonProperty("origClientOrderId")] string OrigClientOrderId,
    [property:JsonProperty("contingencyType")] string ContingencyType,
    [property:JsonProperty("listStatusType")] string ListStatusType,
    [property:JsonProperty("listOrderStatus")] string ListOrderStatus,
    [property:JsonProperty("listClientOrderId")] string ListClientOrderId,
    [property:JsonProperty("transactionTime")] long? TransactionTime,
    [property:JsonProperty("id")] int Id,
    [property:JsonProperty("qty")] string Qty,
    [property:JsonProperty("quoteQty")] string QuoteQty,
    [property:JsonProperty("commission")] string Commission,
    [property:JsonProperty("commissionAsset")] string CommissionAsset,
    [property:JsonProperty("isBuyer")] bool IsBuyer,
    [property:JsonProperty("isMaker")] bool IsMaker,
    [property:JsonProperty("isBestMatch")] bool IsBestMatch,
    [property:JsonProperty("fills")] IReadOnlyList<Fill> Fills,
    [property:JsonProperty("orders")] IReadOnlyList<Order> Orders,
    [property:JsonProperty("orderReports")] IReadOnlyList<Order> OrderReports
);

public enum OrderTypes
{
    LIMIT,
    MARKET,
    STOP_LOSS,
    STOP_LOSS_LIMIT,
    TAKE_PROFIT,
    TAKE_PROFIT_LIMIT,
    LIMIT_MAKER
}