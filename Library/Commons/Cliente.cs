using System;
using System.Collections.Generic;

namespace Library.Commons
{
    public class Cliente {

        public class Cobranca {
            public String Descricao { get; set; }
            public Single Valor { get; set; }
        }

        public String Nome { get; set; }
        public String CPF { get; set; }
        public Endereco Endereco { get; set; }
        public ContaBancaria ContaBancaria { get; set; }
        public List<Cobranca> CobrancaAgendada { get; set; }
        public Single ValorAgendado { get; set; }
        public Int32 QtdRegsLote { get; set; }
        public Single ValorTotal {
            get {
                Single Result = 0;
                if (CobrancaAgendada != null) {
                    foreach (Cobranca Cobranca in CobrancaAgendada) {
                        Result = Result + Cobranca.Valor;
                    }
                }
                return Result;
            }
        }



    }
}
