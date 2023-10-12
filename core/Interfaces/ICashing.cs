namespace infrastructure.Services
{
    public interface ICashing
    {
                Task CasheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
                Task<string> GetCasheResponseAsync(string cacheKey);
    }
}