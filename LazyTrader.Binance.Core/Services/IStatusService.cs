namespace LazyTrader.Binance.Core.Services;

public interface IStatusService
{
    Task<ServiceStatus> GetServiceStatus();
    Task<ServerTime> GetServerTime();
    Task<bool> CheckServerStatus();
}