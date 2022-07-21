namespace LazyTrader.Binance.Core.Exceptions;

public class ArgumentValueIsIncorrectException : ArgumentException
{
    public ArgumentValueIsIncorrectException(string symbolName) 
        : base("Argument value is incorrect", symbolName)
    {
    }
}