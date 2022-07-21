namespace LazyTrader.Binance.Core.Exceptions;

public class ArgumentAboveLimitException : ArgumentException
{
    public readonly int? Limit;
    public ArgumentAboveLimitException(string symbolName, int limit) 
        : base("Argument is above limit", symbolName)
    {
        Limit = limit;
    }
}