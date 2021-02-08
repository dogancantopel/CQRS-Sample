using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRSApi.Queries;
using CQRSApi.Repository;
using CQRSApi.Responses;
using MediatR;

namespace CQRSApi.Handlers
{
    public class GetAuditHandler : IRequestHandler<GetAuditQuery, Audit>
    {
        private IBaseRepository<Audit> _auditRepository;
        public GetAuditHandler(IBaseRepository<Audit> auditRepository)
        {
            _auditRepository = auditRepository;
        }

        public async Task<Audit> Handle(GetAuditQuery request, CancellationToken cancellationToken)
        {
            var audit =  await _auditRepository.Get(request.Id);
            return audit;
        }
         
    }
}