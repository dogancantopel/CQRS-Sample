using CQRSApi.Commands;
using CQRSApi.Repository;
using CQRSApi.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace CQRSApi.Behaviors
{
    public class MongoLogBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    {
        private readonly IBaseRepository<Log> _loggerRepo;
        public MongoLogBehaviour(IBaseRepository<Log> loggerRepo)
        {
            _loggerRepo = loggerRepo;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var log = new Log();
            log.Type = request.GetType().Name;
            log.Request = JsonConvert.SerializeObject(request);
            var response = await next();
            await _loggerRepo.Add(log);
            return response;
        }
    }
}
