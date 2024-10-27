using FlightSystem.Domain.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TokenBlackListRepository : ITokenBlacklistService
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _db;
        public TokenBlackListRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _db = redis.GetDatabase();
        }
        public async Task BlacklistToken(string token)
        {
            // Set token in Redis with a TTL (time to live) if needed
            await _db.StringSetAsync(token, true);
        }

        public async Task<bool> IsTokenBlacklisted(string token)
        {
            return await _db.KeyExistsAsync(token);
        }
    }
}
