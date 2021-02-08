using CQRSApi.Responses;
using MediatR;
using System.Collections.Generic;

namespace CQRSApi.Queries
{
    public class GetAuditQuery : IRequest<Audit>
    {
        public int Id { get; }
        public GetAuditQuery(int id)
        {
            Id = id;
        }
    }
}