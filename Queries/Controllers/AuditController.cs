using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSApi.Commands;
using CQRSApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSApi.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuditController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet]
        public async Task<IActionResult> GetAuditList()
        {
            var query = new GetAuditsQuery();
            var result = await _mediator.Send(query);
            return result!=null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpGet] 
        public async Task<IActionResult> GetAudit(int id)
        {
            var query = new GetAuditQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAudit([FromBody] CreateAuditCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return CreatedAtAction("GetAudit", routeValues: new { id = result.Id }, value: result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
