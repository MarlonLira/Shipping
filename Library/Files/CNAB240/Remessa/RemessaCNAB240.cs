using Library.Commons;
using System;

namespace Library.Arquivos.CNAB240.Remessa {
    public class RemessaCNAB240 {
        public RemessaCNAB240(Empresa Empresa, Cliente Cliente, Int32 SequencialArquivo) {
            this.ClienteSacado = Cliente;
            this.EmpresaCedente = Empresa;
            this.Registros = new Registro() { SequencialArquivo = SequencialArquivo };
        }

        public RemessaCNAB240(Empresa Empresa, Int32 SequencialArquivo) {
            this.EmpresaCedente = Empresa;
            this.Registros = new Registro() { SequencialArquivo = SequencialArquivo };
        }

        public Empresa EmpresaCedente { get; set; }
        public Registro Registros { get; set; }
        public Cliente ClienteSacado { get; set; }
    }
}
