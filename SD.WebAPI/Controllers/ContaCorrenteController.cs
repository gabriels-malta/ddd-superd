using Microsoft.AspNetCore.Mvc;
using SD.Domain.Entities;
using SD.Domain.Interfaces.Services;
using SD.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SD.WebAPI.Controllers
{
    [ApiController]
    [Route("api/contacorrente")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteService _ContaCorrenteService;

        public ContaCorrenteController(SDContext dContext, IContaCorrenteService contaCorrenteService)
        {
            _ContaCorrenteService = contaCorrenteService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<ContaCorrente>> Get()
        {
            return Ok(Enumerable.Empty<ContaCorrente>());
        }
    }
}
