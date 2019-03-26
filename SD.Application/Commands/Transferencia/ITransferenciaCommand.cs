using SD.Domain.ValueObjects;

namespace SD.Application.Commands.Transferencia
{
    public interface ITransferenciaCommand
    {
        Transacao Transferir(TransferenciaModel transferencia);
    }
}
