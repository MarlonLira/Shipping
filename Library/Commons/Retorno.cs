using Library.Banks;
using System;
using System.Collections.Generic;

namespace Library.Commons {
    public class Retorno {

        public List<Cliente> Cliente { get; set; }
        public Empresa Empresa { get; set; }
        public dynamic Banco { get; set; }
        public String CodigoRR { get; set; }
        public String DataGeracao { get; set; }
        public String HoraGeracao { get; set; }
        public Registro Registro { get; set; }
        public String VLayout { get; set; }
        public String SequencialLote { get; set; }
        public String SequencialDetalhe { get; set; }
        public String SequencialArquivo { get; set; }
        public String[] Ocorrencias { get; set; } = new string[5];
        public Int32 TipoInscricaoEmp { get; set; }

        public Retorno() {
            this.Empresa = new Empresa();
            this.Empresa.ContaBancaria = new ContaBancaria();
            this.Empresa.ContaBancaria.AgenciaBancaria = new AgenciaBancaria();
            this.Cliente = new List<Cliente>();
            this.Registro = new Registro();
        }

    }
}
