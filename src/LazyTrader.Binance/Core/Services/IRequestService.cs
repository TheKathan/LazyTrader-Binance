namespace LazyTrader.Binance.Core.Services;

internal interface IRequestService
{
    Task<T> Get<T>(string uri, NameValueCollection? nameValueCollection = null, bool withArguments = true);
    Task<T> Post<T>(string uri, NameValueCollection? nameValueCollection = null);
    Task<TOut> Post<TIn, TOut>(string uri, TIn content, NameValueCollection? nameValueCollection = null);
    Task<string> Post(string uri, NameValueCollection? nameValueCollection = null);
    Task<T> Delete<T>(string uri, NameValueCollection? nameValueCollection = null);
    Task<T> GetWithToken<T>(string uri, string token);
    Task<TOut> PostWithToken<TIn, TOut>(string uri, string token, TIn content);
}
