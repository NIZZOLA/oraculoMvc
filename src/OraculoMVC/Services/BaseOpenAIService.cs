using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace OraculoApi.Services;

public class BaseOpenAIService
{
    protected readonly HttpClient _httpClient;
    private readonly OpenAIConfig _config;
    
    public BaseOpenAIService(HttpClient httpClient, IOptions<OpenAIConfig> options)
    {
        _config = options.Value;
        
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config.AuthSecret);
        _httpClient.BaseAddress = new System.Uri(_config.BaseAddress);
    }
}
