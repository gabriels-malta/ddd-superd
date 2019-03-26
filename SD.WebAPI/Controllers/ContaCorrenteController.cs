using Microsoft.AspNetCore.Mvc;
using SD.Application.Commands;
using SD.Application.Queries;
using SD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;

namespace SD.WebAPI.Controllers
{
    [ApiController]
    [Route("api/contacorrente")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly ITransferenciaCommand _TransferenciaCommand;
        private readonly IContaCorrenteQuery _ContaCorrenteQuery;

        public ContaCorrenteController(IContaCorrenteQuery contaCorrenteQuery, ITransferenciaCommand transferenciaCommand)
        {
            _ContaCorrenteQuery = contaCorrenteQuery;
            _TransferenciaCommand = transferenciaCommand;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ContaCorrenteModel[]))]
        public ActionResult<IEnumerable<ContaCorrente>> Get()
        {
            return Ok(_ContaCorrenteQuery.GetAll());
        }

        [HttpPost, Route("transferir")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult Transferir([FromBody] TransferenciaModel transferencia)
        {
            try
            {
                _TransferenciaCommand.Transferir(transferencia);
                return Ok("Transferência realizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
