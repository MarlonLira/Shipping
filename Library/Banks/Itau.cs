using System;

namespace Library.Banks {
    public class Itau : Banco
    {
        public Itau() {
            Codigo = "341";
            Digito = "7";
            Nome = "BANCO ITAU S.A";
            LocalPagamento = "Pagável em qualquer banco até o vencimento.";
            Moeda = "REA";
        }

        public Itau(Boolean IsComplete) {
        }
    }
}
