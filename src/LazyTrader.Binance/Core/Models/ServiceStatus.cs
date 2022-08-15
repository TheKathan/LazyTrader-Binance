namespace LazyTrader.Binance.Core.Models;

public record ServiceStatus(
    [property:JsonProperty("status")] int Status,
    [property:JsonProperty("msg")] string? Message
);