using SD.Domain.Entities;
using SD.Domain.Exceptions;

namespace SD.Domain.Validators
{
    public abstract class LancamentoValidator
    {
        public static void ValidaOrigemDestino(int origem, int destino)
        {
            if (origem == destino)
                throw new TransferenciaInvalidaException("Conta de origem não pode ser igual a conta destino.");
        }

        public static void VerificarTransferencia(Lancamento origem, Lancamento destino)
        {
            if (!origem.Transacao.Equals(destino.Transacao))
                throw new TransferenciaInvalidaException("Transferência não pode ser realizada.");
        }
    }
}
