namespace LazyTrader.Binance.Infrastructure.Services;

public class SpotService : ISpotService
{
    private readonly ILogger<SpotService> _logger;
    private readonly IRequestService _requestService;
    private readonly IStatusService _statusService;

    public SpotService(ILogger<SpotService> logger, IRequestService requestService, IStatusService statusService)
    {
        _logger = logger;
        _statusService = statusService;
        _requestService = requestService;
    }

    public async Task<Account> GetAccount()
    {
        _logger.LogInformation(">> GetAccount");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

        var result = await _requestService.Get<Account>($"/api/v3/account");

        _logger.LogInformation("<< GetAccount");
        return result;
    }

    public async Task<List<Order>> GetTrades(string symbol,
        long? orderId = null,
        long? startTime = null,
        long? endTime = null,
        long? fromId = null,
        int? limit = null)
    {
        _logger.LogInformation(">> GetTrades");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
        ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));
        ValidationUtils.ArgumentBelowLimit(limit, nameof(symbol), 1000);
        
        var queryValues = HttpUtility.ParseQueryString(string.Empty);
        queryValues.Add("symbol", symbol);

        if (orderId != null)
            queryValues.Add("orderId", orderId.ToString());
        if (startTime != null)
            queryValues.Add("startTime", startTime.ToString());
        if (endTime != null)
            queryValues.Add("endTime", endTime.ToString());
        if (fromId != null)
            queryValues.Add("fromId", fromId.ToString());
        if (limit != null)
            queryValues.Add("limit", limit.ToString());

        var result = await _requestService.Get<List<Order>>($"/api/v3/myTrades", queryValues);

        _logger.LogInformation("<< GetTrades");
        return result;
    }

    public async Task<List<OrderCountUsage>> GetOrderCountUsage()
    {
        _logger.LogInformation(">> OrderCountUsage");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

        var result = await _requestService.Get<List<OrderCountUsage>>($"/api/v3/rateLimit/order");

        _logger.LogInformation("<< OrderCountUsage");
        return result;
    }
    
    public async Task<Order> AddTestOrder(
        string symbol, 
        string side, 
        string type, 
        string? timeInForce = null,
        decimal? quantity = null, 
        decimal? quoteOrderQty = null, 
        decimal? price = null, 
        string? newClientOrderId = null,
        decimal? stopPrice = null, 
        decimal? icebergQty = null, 
        string? newOrderRespType = null)
    {
        _logger.LogInformation(">> TestAddOrder");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
        ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));
        ValidationUtils.ArgumentNotNull(side, nameof(side));
        ValidationUtils.ArgumentNotNull(type, nameof(type));
        ValidationUtils.OrderTypeIsCorrect(type, quantity, price, timeInForce, quoteOrderQty, stopPrice);
        
        var queryValues = HttpUtility.ParseQueryString(string.Empty);
        
        queryValues.Add("symbol", symbol);
        queryValues.Add("side", side);
        queryValues.Add("type", type);

        if (timeInForce != null)
            queryValues.Add("timeInForce", timeInForce);
        if (quantity != null)
            queryValues.Add("quantity", quantity.ToString());
        if (quoteOrderQty != null)
            queryValues.Add("quoteOrderQty", quoteOrderQty.ToString());
        if (price != null)
            queryValues.Add("price", price.ToString());
        if (newClientOrderId != null)
            queryValues.Add("newClientOrderId", newClientOrderId);
        if (stopPrice != null)
            queryValues.Add("stopPrice", stopPrice.ToString());
        if (icebergQty != null)
            queryValues.Add("icebergQty", icebergQty.ToString());
        if (newOrderRespType != null)
            queryValues.Add("newOrderRespType", newOrderRespType);

        var result = await _requestService.Post<Order>($"/api/v3/order/test", queryValues);

        _logger.LogInformation("<< TestAddOrder");
        return result;
    }

    public async Task<Order> AddOrder(
        string symbol, 
        string side, 
        string type, 
        string? timeInForce = null,
        decimal? quantity = null, 
        decimal? quoteOrderQty = null, 
        decimal? price = null, 
        string? newClientOrderId = null,
        decimal? stopPrice = null, 
        decimal? icebergQty = null, 
        string? newOrderRespType = null)
    {
        _logger.LogInformation(">> AddOrder");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
        ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));
        ValidationUtils.ArgumentNotNull(side, nameof(side));
        ValidationUtils.ArgumentNotNull(type, nameof(type));
        ValidationUtils.OrderTypeIsCorrect(type, quantity, price, timeInForce, quoteOrderQty, stopPrice);

        var queryValues = HttpUtility.ParseQueryString(string.Empty);

        queryValues.Add("symbol", symbol);
        queryValues.Add("side", side);
        queryValues.Add("type", type);

        if (timeInForce != null)
            queryValues.Add("timeInForce", timeInForce);
        if (quantity != null)
            queryValues.Add("quantity", quantity.ToString());
        if (quoteOrderQty != null)
            queryValues.Add("quoteOrderQty", quoteOrderQty.ToString());
        if (price != null)
            queryValues.Add("price", price.ToString());
        if (newClientOrderId != null)
            queryValues.Add("newClientOrderId", newClientOrderId);
        if (stopPrice != null)
            queryValues.Add("stopPrice", stopPrice.ToString());
        if (icebergQty != null)
            queryValues.Add("icebergQty", icebergQty.ToString());
        if (newOrderRespType != null)
            queryValues.Add("newOrderRespType", newOrderRespType);

        var result = await _requestService.Post<Order>($"/api/v3/order", queryValues);

        _logger.LogInformation("<< AddOrder");
        return result;
    }

    public async Task<Order> GetOrder(string symbol, long? orderId = null, string? origClientOrderId = null)
    {
        _logger.LogInformation(">> GetOrder");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
        ValidationUtils.ArgumentNotNull(symbol, nameof(symbol));
        // ValidationUtils.ArgumentsAtLeastOneOfTwoIsNotNull(orderId, origClientOrderId);
        // ValidationUtils.ArgumentsOnlyOneNotNull(orderId, origClientOrderId);

        var queryValues = HttpUtility.ParseQueryString(string.Empty);

        queryValues.Add("symbol", symbol);

        if (orderId != null)
            queryValues.Add("orderId", orderId.ToString());
        if (origClientOrderId != null)
            queryValues.Add("origClientOrderId", origClientOrderId);

        var result = await _requestService.Get<Order>($"/api/v3/order", queryValues);

        _logger.LogInformation("<< GetOrder");
        return result;
    }

    public async Task<List<Order>> GetOpenOrders(string symbol)
    {
        _logger.LogInformation(">> GetOpenOrders");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
        
        var queryValues = HttpUtility.ParseQueryString(string.Empty);

        queryValues.Add("symbol", symbol);

        var result = await _requestService.Get<List<Order>>($"/api/v3/openOrders", queryValues);

        _logger.LogInformation("<< GetOpenOrders");
        return result;
    }

    public async Task<List<Order>> GetAllOrders(
        string symbol, 
        long? orderId = null, 
        long? startTime = null,
        long? endTime = null, 
        int? limit = null)
    {
        _logger.LogInformation(">> GetAllOrders");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

        var queryValues = HttpUtility.ParseQueryString(string.Empty);

        queryValues.Add("symbol", symbol);

        if (orderId != null)
            queryValues.Add("orderId", orderId.ToString());
        if (startTime != null)
            queryValues.Add("startTime", startTime.ToString());
        if (endTime != null)
            queryValues.Add("endTime", endTime.ToString());
        if (limit != null)
            queryValues.Add("limit", limit.ToString());

        var result = await _requestService.Get<List<Order>>($"/api/v3/allOrders", queryValues);

        _logger.LogInformation("<< GetAllOrders");
        return result;
    }

    public async Task<Order> CancelOrder(
        long? orderId = null, 
        string? origClientOrderId = null,
        string? newClientOrderId = null)
    {
        _logger.LogInformation(">> CancelOrder");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

        var queryValues = HttpUtility.ParseQueryString(string.Empty);

        if (orderId != null)
            queryValues.Add("orderId", orderId.ToString());
        if (origClientOrderId != null)
            queryValues.Add("origClientOrderId", origClientOrderId);
        if (newClientOrderId != null)
            queryValues.Add("newClientOrderId", newClientOrderId);

        var result = await _requestService.Delete<Order>($"/api/v3/order", queryValues);

        _logger.LogInformation("<< CancelOrder");
        return result;
    }

    public async Task<List<Order>> CancelAllOpenOrders(string symbol)
    {
        _logger.LogInformation(">> CancelAllOpenOrders");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

        var queryValues = HttpUtility.ParseQueryString(string.Empty);

        queryValues.Add("symbol", symbol);

        var result = await _requestService.Delete<List<Order>>($"/api/v3/openOrders", queryValues);

        _logger.LogInformation("<< CancelAllOpenOrders");
        return result;
    }

    public async Task<Order> NewOco(string symbol, 
        string side, 
        decimal quantity, 
        decimal price, 
        decimal stopPrice,
        string? listClientOrderId = null, 
        string? limitClientOrderId = null, 
        decimal? limitIcebergQty = null,
        string? stopClientOrderId = null, 
        decimal? stopLimitPrice = null, 
        decimal? stopIcebergQty = null,
        string? stopLimitTimeInForce = null, 
        string? newOrderRespType = null)
    {
        _logger.LogInformation(">> NewOco");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

        var queryValues = HttpUtility.ParseQueryString(string.Empty);

        queryValues.Add("symbol", symbol);
        queryValues.Add("quantity", quantity.ToString(CultureInfo.InvariantCulture));
        queryValues.Add("price", price.ToString(CultureInfo.InvariantCulture));
        queryValues.Add("stopPrice", stopPrice.ToString(CultureInfo.InvariantCulture));
        
        if (listClientOrderId != null)
            queryValues.Add("listClientOrderId", listClientOrderId);
        if (limitClientOrderId != null)
            queryValues.Add("limitClientOrderId", limitClientOrderId);
        if (limitIcebergQty != null)
            queryValues.Add("limitIcebergQty", limitIcebergQty.ToString());
        if (stopClientOrderId != null)
            queryValues.Add("stopClientOrderId", stopClientOrderId);
        if (stopLimitPrice != null)
            queryValues.Add("stopLimitPrice", stopLimitPrice.ToString());
        if (stopIcebergQty != null)
            queryValues.Add("stopIcebergQty", stopIcebergQty.ToString());
        if (stopLimitTimeInForce != null)
            queryValues.Add("stopLimitTimeInForce", stopLimitTimeInForce);
        if (newOrderRespType != null)
            queryValues.Add("newOrderRespType", newOrderRespType);

        var result = await _requestService.Post<Order>($"/api/v3/order/oco", queryValues);

        _logger.LogInformation("<< NewOco");
        return result;
    }

    public async Task<Order> CancelOco(string symbol, long? orderListId = null, string? listClientOrderId = null, string? newClientOrderId = null)
    {
        _logger.LogInformation(">> CancelOco");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

        var queryValues = HttpUtility.ParseQueryString(string.Empty);

        queryValues.Add("symbol", symbol);
        
        if (listClientOrderId != null)
            queryValues.Add("listClientOrderId", listClientOrderId);
        if (orderListId != null)
            queryValues.Add("orderListId", orderListId.ToString());
        if (newClientOrderId != null)
            queryValues.Add("newClientOrderId", newClientOrderId);
        
        var result = await _requestService.Delete<Order>($"/api/v3/orderList", queryValues);

        _logger.LogInformation("<< CancelOco");
        return result;
    }

    public async Task<Order> GetOco(long? orderListId = null, string? origClientOrderId = null)
    {
        _logger.LogInformation(">> GetOco");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

        var queryValues = HttpUtility.ParseQueryString(string.Empty);
        
        if (orderListId != null)
            queryValues.Add("orderListId", orderListId.ToString());
        if (origClientOrderId != null)
            queryValues.Add("origClientOrderId", origClientOrderId);
        
        var result = await _requestService.Get<Order>($"/api/v3/orderList", queryValues);

        _logger.LogInformation("<< GetOco");
        return result;
    }

    public async Task<List<Order>> GetAllOco(long? fromId = null, long? startTime = null, long? endTime = null, int? limit = null)
    {
        _logger.LogInformation(">> GetAllOco");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());

        var queryValues = HttpUtility.ParseQueryString(string.Empty);
        
        if (fromId != null)
            queryValues.Add("fromId", fromId.ToString());
        if (startTime != null)
            queryValues.Add("startTime", startTime.ToString());
        if (endTime != null)
            queryValues.Add("endTime", endTime.ToString());
        if (limit != null)
            queryValues.Add("limit", limit.ToString());
        
        var result = await _requestService.Get<List<Order>>($"/api/v3/allOrderList", queryValues);

        _logger.LogInformation("<< GetAllOco");
        return result;
    }

    public async Task<List<Order>> GetOpenOco()
    {
        _logger.LogInformation(">> GetOpenOco");

        ValidationUtils.BinanceApiAvailable(await _statusService.CheckServerStatus());
        
        var result = await _requestService.Get<List<Order>>($"/api/v3/openOrderList");

        _logger.LogInformation("<< GetOpenOco");
        return result;
    }
}