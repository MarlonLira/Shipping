using System;

namespace Library.Commons
{
    public class Empresa
    {
        public enum MoraTipo
        {
            Isento,
            JurosSimples,
            IDA = 3

        }

        public String Nome { get; set; }
        public String CNPJ { get; set; }
        public Endereco Endereco { get; set; }
        public String Codigo { get; set; }
        public String Digito { get; set; }
        public ContaBancaria ContaBancaria { get; set; }

        public String OrigemDebito { get; set; }
        public Single Juros { get; set; }
        public Single ValorIDA { get; set; }
        public MoraTipo Mora { get; set; }
    }
}
