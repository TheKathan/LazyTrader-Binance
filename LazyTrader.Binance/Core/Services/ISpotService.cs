namespace LazyTrader.Binance.Core.Services;

public interface ISpotService
{
    Task<Account> GetAccount();

    Task<List<Order>> GetTrades(string symbol, long? orderId = null, long? startTime = null, long? endTime = null,
        long? fromId = null, int? limit = null);

    Task<List<OrderCountUsage>> GetOrderCountUsage();

    Task<Order> AddTestOrder(string symbol, string side, string type, string? timeInForce = null,
        decimal? quantity = null, decimal? quoteOrderQty = null, decimal? price = null, string? newClientOrderId = null,
        decimal? stopPrice = null, decimal? icebergQty = null, string? newOrderRespType = null);

    Task<Order> AddOrder(string symbol, string side, string type, string? timeInForce = null, decimal? quantity = null,
        decimal? quoteOrderQty = null, decimal? price = null, string? newClientOrderId = null,
        decimal? stopPrice = null, decimal? icebergQty = null, string? newOrderRespType = null);

    Task<Order> GetOrder(string symbol, long? orderId = null, string? origClientOrderId = null);
    Task<List<Order>> GetOpenOrders(string symbol);

    Task<List<Order>> GetAllOrders(string symbol, long? orderId = null, long? startTime = null,
        long? endTime = null, int? limit = null);

    Task<Order> CancelOrder(long? orderId = null, string? origClientOrderId = null, string? newClientOrderId = null);
    Task<List<Order>> CancelAllOpenOrders(string symbol);

    Task<Order> NewOco(string symbol, string side, decimal quantity, decimal price, decimal stopPrice,
        string? listClientOrderId = null, string? limitClientOrderId = null, decimal? limitIcebergQty = null,
        string? stopClientOrderId = null, decimal? stopLimitPrice = null, decimal? stopIcebergQty = null,
        string? stopLimitTimeInForce = null, string? newOrderRespType = null);

    Task<Order> CancelOco(string symbol, long? orderListId = null, string? listClientOrderId = null,
        string? newClientOrderId = null);

    Task<Order> GetOco(long? orderListId = null, string? origClientOrderId = null);
    Task<List<Order>> GetAllOco(long? fromId = null, long? startTime = null, long? endTime = null, int? limit = null);
    Task<List<Order>> GetOpenOco();
}