namespace Library.Banks
{
    class Caixa : Banco
    {
        public Caixa() {
            Codigo = "104";
            Digito = "0";
            Nome = "Caixa Econômica Federal";
            LocalPagamento = "Pagável preferencialmente nas agências da Caixa ou Lotéricas.";
            Moeda = "REA";
        }
    }
}
