namespace LazyTrader.Binance.Common.Utils;

public static class ValidationUtils
{
    public static void ArgumentNotNull([NotNull]object? value, string parameterName)
    {
        if (value == null) throw new ArgumentNullException(parameterName);
    }
    
    public static void ResponseNotNull([NotNull]object? value)
    {
        if (value == null) throw new ResponseNullException();
    }

    public static void SuccessfulRequest(HttpResponseMessage response, string responseBody)
    {
        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException($"Request Not Successful. Response : {responseBody}", null, response.StatusCode);
    }
    
    public static void BinanceApiAvailable(bool status)
    {
        if (!status) throw new BinanceApiNotAvailableException();
    }

    public static void ArgumentBelowLimit(long? value, string symbolName, int limit)
    {
        if (value > limit)
            throw new ArgumentAboveLimitException(symbolName, limit);
    }

    public static void ArgumentInsideRangeArray(int value, string symbolName, IEnumerable<int> array)
    {
        if (!array.Contains(value))
            throw new ArgumentOutsideRangeArrayException(symbolName, value);
    }
    
    public static void OrderTypeIsCorrect(string type, decimal? quantity, decimal? price, string? timeInForce, decimal? quoteOrderQty, decimal? stopPrice)
    {
        if (!Enum.TryParse(type.ToUpper(), out OrderTypes orderType)) throw new ArgumentValueIsIncorrectException(nameof(type));
        switch (orderType)
        {
            case OrderTypes.LIMIT:
                ArgumentNotNull(timeInForce, nameof(timeInForce));
                ArgumentNotNull(quantity, nameof(quantity));
                ArgumentNotNull(price, nameof(price));
                break;
            case OrderTypes.MARKET:
                ArgumentNotNull(quantity, nameof(quantity));
                ArgumentNotNull(quoteOrderQty, nameof(quoteOrderQty));
                break;
            case OrderTypes.STOP_LOSS:
                ArgumentNotNull(quantity, nameof(quantity));
                ArgumentNotNull(stopPrice, nameof(stopPrice));
                break;
            case OrderTypes.STOP_LOSS_LIMIT:
                ArgumentNotNull(timeInForce, nameof(timeInForce));
                ArgumentNotNull(quantity, nameof(quantity));
                ArgumentNotNull(price, nameof( price));
                ArgumentNotNull(stopPrice, nameof(stopPrice));
                break;
            case OrderTypes.TAKE_PROFIT:
                ArgumentNotNull(quantity, nameof(quantity));
                ArgumentNotNull(stopPrice, nameof(stopPrice));
                break;
            case OrderTypes.TAKE_PROFIT_LIMIT:
                ArgumentNotNull(timeInForce, nameof(timeInForce));
                ArgumentNotNull(quantity, nameof(quantity));
                ArgumentNotNull(price, nameof( price));
                ArgumentNotNull(stopPrice, nameof(stopPrice));
                break;
            case OrderTypes.LIMIT_MAKER:
                ArgumentNotNull(quantity, nameof(quantity));
                ArgumentNotNull(price, nameof(price));
                break;
            default:
                throw new ArgumentValueIsIncorrectException(nameof(type));
        }
    }

    public static void AtLeastOneArgumentIsNotNull(params object[] parameters)
    {
        if (parameters.Any(value => value != null))
        {
            return;
        }

        throw new ArgumentsAreAllNullException();
    }

    public static void ArgumentsAtLeastOneOfTwoIsNotNull(object? value1, object? value2)
    {
        if (value1 == null && value2 == null) 
            throw new ArgumentsAreAllNullException();
    }
    
    public static void ArgumentsOnlyOneCanBeUsed(object? value1, object? value2)
    {
        if (value1 != null && value2 != null) 
            throw new ArgumentsOnlyOneCanBeUsedException();
    }
}