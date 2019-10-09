using System;
using System.Collections.Generic;
﻿using Library.Commons;
using System;

namespace Library.Files.CNAB150.Remessa
{
    public class RemessaCNAB150
    {
        public RemessaCNAB150(Empresa Empresa, Cliente Cliente, Int32 SequencialArquivo) {
            this.ClienteSacado = Cliente;
            this.EmpresaCedente = Empresa;
            this.Registros = new Registro() { SequencialArquivo = SequencialArquivo };
        }

        public RemessaCNAB150(Empresa Empresa, Int32 SequencialArquivo) {
            this.EmpresaCedente = Empresa;
            this.Registros = new Registro() { SequencialArquivo = SequencialArquivo };
        }

        public Empresa EmpresaCedente { get; set; }
        public Registro Registros { get; set; }
        public Cliente ClienteSacado { get; set; }

    }
}
