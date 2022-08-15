namespace LazyTrader.Binance.Core.Exceptions;

public class ArgumentOutsideRangeException : ArgumentException
{
    public readonly int? Min;
    public readonly int? Max;
    public ArgumentOutsideRangeException(string symbolName, int min, int max) 
        : base("Argument outside range", symbolName)
    {
        Min = min;
        Max = max;
    }
}