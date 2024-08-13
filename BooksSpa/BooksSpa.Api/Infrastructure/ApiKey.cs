using System.Security.Claims;
using AspNetCore.Authentication.ApiKey;

namespace BooksSpa.Api.Infrastructure;

public class ApiKey(string key) : IApiKey
{
    public string Key { get; } = key;
    public string OwnerName { get; } = string.Empty;
    public IReadOnlyCollection<Claim> Claims { get; } = Array.Empty<Claim>();
}