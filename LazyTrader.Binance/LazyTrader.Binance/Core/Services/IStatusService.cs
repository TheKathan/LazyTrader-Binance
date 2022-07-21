namespace LazyTrader.Binance.Core.Services;

internal interface IStatusService
{
    Task<ServiceStatus> GetServiceStatus();
    Task<ServerTime> GetServerTime();
    Task<bool> CheckServerStatus();
}