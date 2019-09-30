namespace Library.Banks
{
    class Santander : Banco
    {
        public Santander() {
            Codigo = "033";
            Digito = "7";
            Nome = "Santander";
            LocalPagamento = "Pagar preferencialmente no banco santander";
            Moeda = "REA";
        }
    }
}
