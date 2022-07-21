namespace LazyTrader.Binance;

public static class BinanceServiceCollectionExtension
{
    public static IServiceCollection AddBinance(this IServiceCollection services, int throttleSleepTime = 10000)
    {
        services.AddScoped<Spot>(); 
        services.AddScoped<Market>(); 
        
        services.AddScoped<IRequestService, RequestService>();
        services.AddScoped<ISpotService, SpotService>();
        services.AddScoped<IMarketService, MarketService>();
        services.AddScoped<IStatusService, StatusService>();
        
        // Policy to wait in case of too many calls, 429 error
        var policy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(response => (int)response.StatusCode == 429)
            .WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(throttleSleepTime));

        services.AddHttpClient<IRequestService, RequestService>("BinanceApi",
                client =>
                {
                    client.BaseAddress = new Uri("https://api.binance.com");
                })
            .AddPolicyHandler(policy);
        return services;
    }
}