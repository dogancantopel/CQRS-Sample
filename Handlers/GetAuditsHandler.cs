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
    public class GetAuditsHandler : IRequestHandler<GetAuditsQuery, List<Audit>>
    {
        private IBaseRepository<Audit> _auditRepository;
        public GetAuditsHandler(IBaseRepository<Audit> auditRepository)
        {
            _auditRepository = auditRepository;
        }

        public  Task<List<Audit>> Handle(GetAuditsQuery request, CancellationToken cancellationToken)
        {
            var audits =  _auditRepository.GetAllList(null);
            return audits;
        }
    }
}