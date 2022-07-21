namespace LazyTrader.Binance.Application;

public class Spot
{
    private readonly ILogger<Spot> _logger;
    private readonly ISpotService _spotService;
    
    public Spot(ILogger<Spot> logger, ISpotService spotService)
    {
        _logger = logger;
        _spotService = spotService;
    }

    public async Task<Account> GetAccount()
    {
        _logger.LogInformation("> Account");

        var result = await _spotService.GetAccount();
        
        _logger.LogInformation("< Account");
        return result;
    }
    
    public async Task<List<Order>> GetTrades(string symbol, long? orderId = null, long? startTime = null, long? endTime = null, long? fromId = null, int? limit = null)
    {
        _logger.LogInformation("> GetTrades");
        
        var result = await _spotService.GetTrades(symbol, orderId, startTime, endTime, fromId, limit);
        
        _logger.LogInformation("< GetTrades");
        return result;
    }
    
    public async Task<List<OrderCountUsage>> GetOrderCountUsage()
    {
        _logger.LogInformation("> GetOrderCountUsage");

        var result = await _spotService.GetOrderCountUsage();
        
        _logger.LogInformation("< GetOrderCountUsage");
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
        _logger.LogInformation("> AddTestOrder");

        var result = await _spotService.AddTestOrder(symbol, side, type, timeInForce, quantity, quoteOrderQty, price, newClientOrderId, stopPrice, icebergQty, newOrderRespType);
        
        _logger.LogInformation("< AddTestOrder");
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
        _logger.LogInformation("> AddOrder");

        var result = await _spotService.AddOrder(symbol, side, type, timeInForce, quantity, quoteOrderQty, price, newClientOrderId, stopPrice, icebergQty, newOrderRespType);
        
        _logger.LogInformation("< AddOrder");
        return result;
    }

    public async Task<Order> GetOrder(string symbol, long? orderId = null, string? origClientOrderId = null)
    {
        _logger.LogInformation("> GetOrder");

        var result = await _spotService.GetOrder(symbol, orderId, origClientOrderId);
        
        _logger.LogInformation("< GetOrder");
        return result;
    }
}