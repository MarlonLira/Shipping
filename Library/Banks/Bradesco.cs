namespace Library.Banks
{
    class Bradesco : Banco
    {
        public Bradesco() {
            Codigo = "237";
            Digito = "2";
            Nome = "Bradesco";
            LocalPagamento = "Pagável preferencialmente nas Agências Bradesco.";
            Moeda = "REA";
        }
    }
}
