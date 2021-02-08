using CQRSApi.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSApi.Validator
{
    public class AuditCommandValidator:AbstractValidator<CreateAuditCommand>
    {
        public AuditCommandValidator()
        {
            RuleFor(x => x.SalesPointId).NotEmpty();
            RuleFor(x => x.ProjectId).NotEmpty();
            RuleFor(x => x.SalesPointName).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
