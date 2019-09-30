﻿using Library.Commons;
using System;

namespace Library.Arquivos.CNAB240.Remessa
{
    public class RemessaCNAB240
    {
        //Empresa

        public RemessaCNAB240(Empresa Empresa, Cliente Cliente, Int32 SequencialArquivo) {
            this.ClienteSacado = Cliente;
            this.EmpresaCedente = Empresa;
            this.SequencialNsa = SequencialArquivo;
        }

        public RemessaCNAB240(Empresa Empresa) {
            this.EmpresaCedente = Empresa;
        }

        public Empresa EmpresaCedente { get; set; }
        public Registro Registros { get; set; }
        public Cliente ClienteSacado { get; set; }
        public int LoteServico { get; set; }
        public string NomeBanco { get; set; }
        public string CodigoRemessa { get; set; }
        public DateTime DataGeracao { get; set; }
        public DateTime HoraGeracao { get; set; }
        public int SequencialNsa { get; set; }
        public string VersaoLayout { get; set; }
        public string Densidade { get; set; }
        public string ReservadoBanco { get; set; }
        public string ReservadoEmpresa { get; set; }
        public string VersaoAplicativo { get; set; }
    }
}
