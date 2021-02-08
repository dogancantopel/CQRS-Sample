using CQRSApi.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSApi.Commands
{
    public class CreateAuditCommand : IRequest<Audit>
    {
        public int UserId { get; set; }
        public int SalesPointId { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public string SalesPointName { get; set; }
    }
}
