using CQRSApi.Responses;
using MediatR;
using System.Collections.Generic;

namespace CQRSApi.Queries
{
    public class GetAuditsQuery : IRequest<List<Audit>>
    {
        public GetAuditsQuery()
        {
        }
    }
}