using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoTrack.Application;
using InfoTrack.Domain;
using InfoTrack.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeoController : ControllerBase
    {
        private readonly IMediator _mediator;        
        public SeoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetSearchRankings(SeoSearchRequest request)
        {           
            var query = new GetSiteSearchRankingQuery(request.Keywords, request.Url, request.SearchProvider);
            var result = await _mediator.Send(query);
            return Ok(result);       
        }
    }
}