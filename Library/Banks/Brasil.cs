namespace Library.Banks
{
    class Brasil : Banco
    {
        public Brasil() {
            Codigo = "001";
            Digito = "9";
            Nome = "Banco do Brasil";
            LocalPagamento = "Pagável em qualquer banco até o vencimento.";
            Moeda = "REA";
        }
    }
}
