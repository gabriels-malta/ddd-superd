using System.Collections.Generic;
using SD.Domain.Entities;
using SD.Domain.Interfaces.Repositories;
using SD.Domain.Interfaces.Services;
using SD.Domain.Validators;
using SD.Domain.ValueObjects;

namespace SD.Application.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _LancamentoRepository;

        public LancamentoService(ILancamentoRepository repository) => _LancamentoRepository = repository;

        public IEnumerable<Lancamento> GetByTransacao(Transacao transacao)
        {
            return _LancamentoRepository.GetByTransacao(transacao);
        }

        public Transacao Registrar(Lancamento lancamento)
        {
            LancamentoValidator.ValidaValor(lancamento.Valor);
            _LancamentoRepository.Save(lancamento);
            return new Transacao(lancamento.Transacao);
        }

        public Transacao RegistrarTransferencia(Lancamento origem, Lancamento destino)
        {
            LancamentoValidator.ValidaOrigemDestino(origem.ContaId, destino.ContaId);

            destino.LinkarTransacao(origem.Transacao);

            LancamentoValidator.VerificarTransferencia(origem, destino);

            _LancamentoRepository.Save(origem);
            _LancamentoRepository.Save(destino);

            return new Transacao(origem.Transacao);
        }
    }
}
