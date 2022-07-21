namespace LazyTrader.Binance.Core.Exceptions;

public class ArgumentsAreAllNullException : Exception
{
    public ArgumentsAreAllNullException() : base("All arguments are null")
    {
    }
}