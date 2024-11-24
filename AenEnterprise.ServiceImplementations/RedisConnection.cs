using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AenEnterprise.ServiceImplementations
{
    public class RedisConnection
    {
        private readonly ConnectionMultiplexer _redis;

        public RedisConnection(string connectionString)
        {
            try
            {
                _redis = ConnectionMultiplexer.Connect(connectionString);
            }
            catch (Exception ex)
            {
                // Handle exception (logging, rethrowing, etc.)
                throw new InvalidOperationException("Could not connect to Redis.", ex);
            }
        }

        public IDatabase GetDatabase()
        {
            return _redis.GetDatabase();
        }
        

    }

}
