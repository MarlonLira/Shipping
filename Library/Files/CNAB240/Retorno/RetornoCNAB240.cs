using Library.Commons;
using System;
using System.Collections.Generic;

namespace Library.Files.CNAB240.Retorno
{
    public class RetornoCNAB240 {

        public HeaderFile HeaderFile { get; set; }
        public List<Allotment> Allotment { get; set; }
        public TrailerFile TrailerFile { get; set; }

        public RetornoCNAB240() {
            HeaderFile = new HeaderFile();
            Allotment = new List<Allotment>();
            TrailerFile = new TrailerFile();
        }
    }
    public class Allotment
    {
        public HeaderAllotment HeaderAllotment { get; set; }
        public List<DetailsAllotment> DetailsAllotment { get; set; }
        public TrailerAllotment TrailerAllotment { get; set; }
        public Allotment() {
            HeaderAllotment = new HeaderAllotment();
            DetailsAllotment = new List<DetailsAllotment>();
            TrailerAllotment = new TrailerAllotment();
        }
    }
    public class HeaderFile {
        public Empresa Empresa { get; set; }
        public dynamic Banco { get; set; }
        public String CodigoRR { get; set; }
        public String DataGeracao { get; set; }
        public String HoraGeracao { get; set; }
        public String VLayout { get; set; }
        public String SequencialArquivo { get; set; }
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
            this.Empresa.Endereco = new Endereco();
            this.Empresa.ContaBancaria.AgenciaBancaria = new AgenciaBancaria();
        }
    }
    public class DetailsAllotment {
        public Cliente Cliente { get; set; }
        public Empresa Empresa { get; set; }
        public dynamic Banco { get; set; }
        public String CodigoIM { get; set; }
        public String SequencialDetalhe { get; set; }
        public String DocumentoBanco { get; set; }
        public String DataLancto { get; set; }
        public List<String> Ocorrencias { get; set; }
        public DetailsAllotment() {
            this.Empresa = new Empresa();
            this.Empresa.ContaBancaria = new ContaBancaria();
            this.Empresa.ContaBancaria.AgenciaBancaria = new AgenciaBancaria();
            this.Cliente = new Cliente();
            this.Cliente.ContaBancaria = new ContaBancaria();
            this.Cliente.ContaBancaria.AgenciaBancaria = new AgenciaBancaria();
        }
    }
    public class TrailerAllotment {
        public List<Cliente> Cliente { get; set; }
        public dynamic Banco { get; set; }
        public Registro Registro { get; set; }
        public Single ValorDebitoTotal { get; set; }
        public Single ValorMoedaTotal { get; set; }
        public String SequencialLote { get; set; }
        public String Ocorrencias { get; set; }

        public TrailerAllotment() {
            this.Cliente = new List<Cliente>();
            this.Registro = new Registro();
        }
    }
    public class TrailerFile {
        public dynamic Banco { get; set; }
        public Registro Registro { get; set; }
        public String SequencialLote { get; set; }

        public TrailerFile() {
            this.Registro = new Registro();
        }
    }
}
