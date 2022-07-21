namespace LazyTrader.Binance.Common.Utils;

public static class TimeUtils
{
    public static long GetUnixTimestamp()
    {
        return GetUnixTimestamp(DateTime.UtcNow);
    }

    private static long GetUnixTimestamp(DateTime date)
    {
        var zero = new DateTime(1970, 1, 1);
        var span = date.Subtract(zero);

        return (long)span.TotalMilliseconds - 1000;
    }
}