namespace Library.Banks {
    public class Itau : Banco
    {
        public Itau() {
            Codigo = "341";
            Digito = "7";
            Nome = "Itaú";
            LocalPagamento = "Pagável em qualquer banco até o vencimento.";
            Moeda = "REA";
        }
    }
}
