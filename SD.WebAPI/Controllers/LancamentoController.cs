using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SD.Application.Queries.Lancamento;
using SD.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SD.WebAPI.Controllers
{
    [ApiController]
    [Route("api/lancamento")]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoQuery _query;

        public LancamentoController(ILancamentoQuery query)
        {
            _query = query;
        }

        [HttpGet]
        [Route("{transacao}", Name = "Lancamento_PorTransaca")]
        public ActionResult<IEnumerable<LancamentoModel>> Get(Guid transacao)
        {
            return Ok(_query.GetLancamentosByTransacao(new Transacao(transacao)));
        }
    }
}
