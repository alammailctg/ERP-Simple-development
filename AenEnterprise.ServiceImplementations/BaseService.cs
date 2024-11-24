using AenEnterprise.DataAccess.RepositoryInterface.HumanResourceRepositoriesInterace;
using AenEnterprise.DataAccess.RepositoryInterface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace AenEnterprise.ServiceImplementations
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IDatabase _redisDb;
        protected readonly RedisConnection _redisConnection;
        protected readonly ILogger<BaseService> _logger;

        protected BaseService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDatabase redisDb,
            RedisConnection redisConnection,
            ILogger<BaseService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _redisDb = redisConnection.GetDatabase();
            _redisConnection = redisConnection;
            _logger = logger;
        }
    }

}
