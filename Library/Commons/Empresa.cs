using System;

namespace Library.Commons
{
    public class Empresa
    {
        public String Nome { get; set; }
        public String CNPJ { get; set; }
        public String Codigo { get; set; }
        public String Digito { get; set; }
        public ContaBancaria ContaBancaria { get; set; }
    }
}
