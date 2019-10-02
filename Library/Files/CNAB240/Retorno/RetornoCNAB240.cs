using Library.Commons;
using System;
using System.Collections.Generic;

namespace Library.Files.CNAB240.Retorno
{
    public class RetornoCNAB240 {

        public HeaderFile HeaderFile { get; set; }
        public HeaderAllotment HeaderAllotment { get; set; }
        public DetailsAllotment DetailsAllotment { get; set; }
        public TrailerAllotment TrailerAllotment { get; set; }
        public TrailerFile TrailerFile { get; set; }
    }

    public class HeaderFile {
        public Empresa Empresa { get; set; }
        public dynamic Banco { get; set; }
        public String CodigoRR { get; set; }
        public String DataGeracao { get; set; }
        public String HoraGeracao { get; set; }
        public String VLayout { get; set; }
        public String SequencialLote { get; set; }
        public String SequencialDetalhe { get; set; }
        public String SequencialArquivo { get; set; }
        public String[] Ocorrencias { get; set; } = new string[5];
        public Int32 TipoInscricaoEmp { get; set; }

        public HeaderFile() {
            this.Empresa = new Empresa();
            this.Empresa.ContaBancaria = new ContaBancaria();
            this.Empresa.ContaBancaria.AgenciaBancaria = new AgenciaBancaria();
        }
    }

    public class HeaderAllotment {
        public Empresa Empresa { get; set; }
        public dynamic Banco { get; set; }
        public String Ocorrencias { get; set; }
        public Int32 TipoInscricaoEmp { get; set; }

        public HeaderAllotment() {
            this.Empresa = new Empresa();
            this.Empresa.ContaBancaria = new ContaBancaria();
            this.Empresa.ContaBancaria.AgenciaBancaria = new AgenciaBancaria();
        }
    }

    public class DetailsAllotment {
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

        public DetailsAllotment() {
            this.Empresa = new Empresa();
            this.Empresa.ContaBancaria = new ContaBancaria();
            this.Empresa.ContaBancaria.AgenciaBancaria = new AgenciaBancaria();
            this.Cliente = new List<Cliente>();
            this.Registro = new Registro();
        }
    }
    public class TrailerAllotment {
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

        public TrailerAllotment() {
            this.Empresa = new Empresa();
            this.Empresa.ContaBancaria = new ContaBancaria();
            this.Empresa.ContaBancaria.AgenciaBancaria = new AgenciaBancaria();
            this.Cliente = new List<Cliente>();
            this.Registro = new Registro();
        }
    }
    public class TrailerFile {
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

        public TrailerFile() {
            this.Empresa = new Empresa();
            this.Empresa.ContaBancaria = new ContaBancaria();
            this.Empresa.ContaBancaria.AgenciaBancaria = new AgenciaBancaria();
            this.Cliente = new List<Cliente>();
            this.Registro = new Registro();
        }
    }
}
