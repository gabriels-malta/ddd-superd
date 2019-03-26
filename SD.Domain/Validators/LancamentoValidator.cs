using SD.Domain.Entities;
using SD.Domain.Exceptions;
using SD.Domain.ValueObject;

namespace SD.Domain.Validators
{
    public abstract class LancamentoValidator
    {
        public static void ValidaOrigemDestino(int origem, int destino)
        {
            if (origem == destino)
                throw new TransferenciaInvalidaException("Conta de origem não pode ser igual a conta destino.");
        }

        public static void ValidaValor(decimal valor)
        {
            var _valor = (Valor)valor;
            if (!_valor.IsValid())
                throw new TransferenciaInvalidaException($"Valor ({_valor.ToString()}) inválido para operação.");
        }

        public static void VerificarTransferencia(Lancamento origem, Lancamento destino)
        {
            if (origem.Transacao != destino.Transacao)
                throw new TransferenciaInvalidaException("Transferência não pode ser realizada.");
        }
    }
}
