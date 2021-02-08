using CQRSApi.Commands;
using CQRSApi.Repository;
using CQRSApi.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSApi.Handlers
{
    public class CreateAuditHandler : IRequestHandler<CreateAuditCommand, Audit>
    {
        private IBaseRepository<Audit> _auditRepository;
        public CreateAuditHandler(IBaseRepository<Audit> auditRepository)
        {
            _auditRepository = auditRepository;
        }

        public async Task<Audit> Handle(CreateAuditCommand request, CancellationToken cancellationToken)
        {
            var audit = await _auditRepository.Add(new Audit {UserId=request.UserId,ProjectId=request.ProjectId,SalesPointId=request.SalesPointId,StartDate=request.StartDate,SalesPointName=request.SalesPointName });
            return audit;
        } 
    }
}
