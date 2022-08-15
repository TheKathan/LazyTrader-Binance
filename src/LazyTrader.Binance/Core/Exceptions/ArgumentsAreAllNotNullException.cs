namespace LazyTrader.Binance.Core.Exceptions;

public class ArgumentsOnlyOneCanBeUsedException : Exception
{
    public ArgumentsOnlyOneCanBeUsedException() : base("Only one argument can be used")
    {
    }
}