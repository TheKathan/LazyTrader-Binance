namespace LazyTrader.Binance.Core.Exceptions;

public class ResponseNullException : Exception
{
    public ResponseNullException() : base("Request response returned empty")
    {
        
    }
}