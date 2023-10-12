using System.Text.Json;
using StackExchange.Redis;

namespace infrastructure.Services
{
    public class CashingService : ICashing
    {
        public readonly IDatabase _database ;
        public CashingService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

       
        public async Task CasheResponseAsync(string casheKey, object response, TimeSpan timeToLive)
        {
            if(response==null) return;

            var options = new JsonSerializerOptions{
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var serializeResponse = JsonSerializer.Serialize(response,options);

            await  _database.StringSetAsync(casheKey,serializeResponse,timeToLive);

        }

        

        public async Task<string> GetCasheResponseAsync(string casheKey)
        {
            var cashedResponse = await _database.StringGetAsync(casheKey);

            if(cashedResponse.IsNullOrEmpty) return null;

            return cashedResponse;
        }
    }
}