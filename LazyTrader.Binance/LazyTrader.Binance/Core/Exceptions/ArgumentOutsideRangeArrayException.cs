namespace LazyTrader.Binance.Core.Exceptions;

public class ArgumentOutsideRangeArrayException : ArgumentException
{
    public readonly int? Limit;
    public ArgumentOutsideRangeArrayException(string symbolName, int limit) 
        : base("Argument value is ouside of allowed range", symbolName)
    {
        Limit = limit;
    }
}