using System;

namespace SD.Domain.ValueObjects
{
    public class Transacao
    {
        private Guid _transacao;

        public Transacao() => _transacao = Guid.NewGuid();
        public Transacao(Guid guid) => _transacao = guid;

        public static implicit operator Guid(Transacao transacao) => transacao._transacao;
    }
}
