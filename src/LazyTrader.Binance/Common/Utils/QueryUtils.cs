namespace LazyTrader.Binance.Common.Utils;

public static class QueryUtils
{
    public static NameValueCollection BuildInitialQuery(string secret)
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        queryString.Add("timestamp", TimeUtils.GetUnixTimestamp().ToString());
        queryString.Add("signature", SignatureUtils.CreateSignature(queryString.ToString(), secret));
        
        return queryString;
    }
    public static NameValueCollection BuildQuery(string secret, NameValueCollection? nameValueCollection = null)
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);

        if (nameValueCollection != null) queryString.Add(nameValueCollection);
        queryString.Add("timestamp", TimeUtils.GetUnixTimestamp().ToString());
        queryString.Add("signature", SignatureUtils.CreateSignature(queryString.ToString(), secret));
        
        return queryString;
    }
}