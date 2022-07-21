namespace LazyTrader.Binance.Core.Exceptions;

public class BinanceApiNotAvailableException : Exception
{
    public BinanceApiNotAvailableException() : base("Binance Api Service Not Available")
    {
    }
}