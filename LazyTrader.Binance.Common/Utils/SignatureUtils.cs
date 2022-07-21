namespace LazyTrader.Binance.Common.Utils;

public static class SignatureUtils
{
    public static string CreateSignature(string? queryString, string secret)
    {
        if (queryString == null) return string.Empty;
        
        var keyBytes = Encoding.UTF8.GetBytes(secret);
        var queryStringBytes = Encoding.UTF8.GetBytes(queryString);
        var hmacsha256 = new HMACSHA256(keyBytes);
        var bytes = hmacsha256.ComputeHash(queryStringBytes);

        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
}
