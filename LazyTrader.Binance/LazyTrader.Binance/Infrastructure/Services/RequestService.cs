using System.Collections.Specialized;
using System.Net.Http.Json;

namespace LazyTrader.Binance.Infrastructure.Services;

internal class RequestService : IRequestService
{
    private readonly ILogger<RequestService> _logger;
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public RequestService(ILogger<RequestService> logger, HttpClient httpClient, IConfiguration configuration)
    {
        _logger = logger;
        _httpClient = httpClient;
        _configuration = configuration;

        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        _httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", configuration["Binance:Key"]);
        _httpClient.DefaultRequestHeaders.Add("recvWindow", configuration["Binance:RecvWindown"]);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    
    public async Task<T> GetWithToken<T>(string uri, string token)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Add("Api-Token", token);
            
            using var response = await _httpClient.GetAsync(uri);
            
            var responseBody = await response.Content.ReadAsStringAsync();
            ValidationUtils.SuccessfulRequest(response, responseBody);
    
            var result = JsonConvert.DeserializeObject<T>(responseBody);
            ValidationUtils.ResponseNotNull(result);
            
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message} : {StackTrace}", ex.Message, ex.StackTrace);
            throw;
        }
    }

    public async Task<TOut> PostWithToken<TIn, TOut>(string uri, string token, TIn content)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Add("Api-Token", token);
            
            var serialized = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync(uri, serialized);
            
            var responseBody = await response.Content.ReadAsStringAsync();
            ValidationUtils.SuccessfulRequest(response, responseBody);

            var result = JsonConvert.DeserializeObject<TOut>(responseBody);
            ValidationUtils.ResponseNotNull(result);
            
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message} : {StackTrace}", ex.Message, ex.StackTrace);
            throw;
        }
    }

    public async Task<T> Get<T>(string uri, NameValueCollection? nameValueCollection = null, bool withArguments = true)
    {
        if (withArguments)
        {
            var queryString = QueryUtils.BuildInitialQuery(_configuration["Binance:Secret"]);
            if (nameValueCollection != null) queryString.Add(nameValueCollection);
            uri = $"{uri}?{queryString}";
        }

        try
        {
            using var response = await _httpClient.GetAsync(uri);
            var responseBody = await response.Content.ReadAsStringAsync();
            ValidationUtils.SuccessfulRequest(response, responseBody);

            var result = JsonConvert.DeserializeObject<T>(responseBody);
            ValidationUtils.ResponseNotNull(result);
            
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message} : {StackTrace}", ex.Message, ex.StackTrace);
            throw;
        }
    }
    
    public async Task<T> Get<T>(string uri)
    {
        try
        {
            using var response = await _httpClient.GetAsync($"{uri}");
            var responseBody = await response.Content.ReadAsStringAsync();
            ValidationUtils.SuccessfulRequest(response, responseBody);

            var result = JsonConvert.DeserializeObject<T>(responseBody);
            ValidationUtils.ResponseNotNull(result);
            
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message} : {StackTrace}", ex.Message, ex.StackTrace);
            throw;
        }
    }

    public async Task<T> Post<T>(string uri, NameValueCollection? nameValueCollection = null)
    {
        var queryString = QueryUtils.BuildQuery(_configuration["Binance:Secret"], nameValueCollection);
        
        try
        {
            var serialized = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync($"{uri}?{queryString}", serialized);
            
            var responseBody = await response.Content.ReadAsStringAsync();
            ValidationUtils.SuccessfulRequest(response, responseBody);
            
            var result = await response.Content.ReadFromJsonAsync<T>();;
            ValidationUtils.ResponseNotNull(result);
            
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message} : {StackTrace}", ex.Message, ex.StackTrace);
            throw;
        }
    }

    public async Task<TOut> Post<TIn, TOut>(string uri, TIn content, NameValueCollection? nameValueCollection = null)
    {
        var queryString = QueryUtils.BuildInitialQuery(_configuration["Binance:Secret"]);
        if (nameValueCollection != null) queryString.Add(nameValueCollection);
        
        try
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var serialized = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync($"{uri}?{queryString}", serialized);
            
            var responseBody = await response.Content.ReadAsStringAsync();
            ValidationUtils.SuccessfulRequest(response, responseBody);
            
            var result = JsonConvert.DeserializeObject<TOut>(responseBody);
            ValidationUtils.ResponseNotNull(result);
            
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message} : {StackTrace}", ex.Message, ex.StackTrace);
            throw;
        }
    }

    public async Task<T> Delete<T>(string uri, NameValueCollection? nameValueCollection = null)
    {
        var queryString = QueryUtils.BuildInitialQuery(_configuration["Binance:Secret"]);
        if (nameValueCollection != null) queryString.Add(nameValueCollection);

        try
        {
            using var response = await _httpClient.DeleteAsync($"{uri}?{queryString}");
            var responseBody = await response.Content.ReadAsStringAsync();
            ValidationUtils.SuccessfulRequest(response, responseBody);

            var result = JsonConvert.DeserializeObject<T>(responseBody);
            ValidationUtils.ResponseNotNull(result);
            
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message} : {StackTrace}", ex.Message, ex.StackTrace);
            throw;
        }
    }
}
