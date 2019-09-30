namespace Dispatch.Commons.Banks
{
    public class Bancos
    {
        public Bank Banco { get; set; }
    }

    public enum Bank
    {
        Itau = 341,
        Caixa = 104,
        Santander = 033,
        Brasil = 001,
        Bradesco = 237
    }
}
