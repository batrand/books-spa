using AspNetCore.Authentication.ApiKey;
using BooksSpa.Api.Options;
using Microsoft.Extensions.Options;

namespace BooksSpa.Api.Infrastructure;

public class ApiKeyProvider: IApiKeyProvider
{
    private readonly AuthOptions _auth;
    private readonly ILogger<ApiKeyProvider> _logger;

    public ApiKeyProvider(IOptions<AuthOptions> auth, ILogger<ApiKeyProvider> logger)
    {
        _logger = logger;
        _auth = auth.Value;
    }

    public async Task<IApiKey?> ProvideAsync(string key)
    {
        try
        {
            return _auth.ApiKey.Equals(key) 
                ? new ApiKey(key) 
                : null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception when validating API Key");
            return null;
        }
    }
}