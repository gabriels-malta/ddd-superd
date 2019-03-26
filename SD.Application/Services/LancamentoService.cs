using SD.Domain.Entities;
using SD.Domain.Interfaces.Services;
using SD.Domain.Validators;
using SD.Domain.ValueObject;
using SD.Domain.ValueObjects;

namespace SD.Application.Services
{
    public class LancamentoService : ILancamentoService
    {
        public Transacao Registrar(Lancamento lancamento)
        {
            LancamentoValidator.ValidaValor(lancamento.Valor);

            return new Transacao(lancamento.Transacao);
        }

        public Transacao RegistrarTransferencia(Lancamento origem, Lancamento destino)
        {
            LancamentoValidator.ValidaOrigemDestino(origem.ContaId, destino.ContaId);

            destino.LinkarTransacao(origem.Transacao);

            LancamentoValidator.VerificarTransferencia(origem, destino);

            return new Transacao(origem.Transacao);
        }
    }
}
