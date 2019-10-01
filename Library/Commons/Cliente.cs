using System;
using System.Collections.Generic;

namespace Library.Commons
{
    public class Cliente {
        public String Nome { get; set; }
        public String CPF { get; set; }
        public Endereco Endereco { get; set; }
        public ContaBancaria ContaBancaria { get; set; }
        public List<Cobranca> CobrancaAgendada { get; set; }
        public Single ValorAgendado { get; set; }
        public DateTime DataCobranca { get; set; }
        public Single ValorMoeda { get; set; }
        public Int32 QtdRegsLote { get { return CobrancaAgendada == null? 0 : 2 + CobrancaAgendada.Count; } }
        public Single ValorTotal {
            get {
                Single Result = 0;
                if (CobrancaAgendada != null) {
                    foreach (Cobranca Cobranca in CobrancaAgendada) {
                        Result += Cobranca.Valor;
                    }
                }
                return Result;
            }
        }
        public Single ValorMoedaTotal {
            get {
                Single Result = 0;
                if (CobrancaAgendada != null) {
                    foreach (Cobranca Cobranca in CobrancaAgendada) {
                        Result += (Cobranca.Valor * Cobranca.PctIOF);
                    }
                }
                return Result;
            }
        }

        public void Verificar() {
            String Error = String.Empty;
            if (String.IsNullOrEmpty(Nome)) {
                Error += "O nome do cliente não foi informado!";
                this.Nome = "[nome não informado]";
            }
            if (String.IsNullOrEmpty(CPF)) {
                Error += "O CPF do cliente " + Nome +" não foi informado!";
            }
            if (Endereco == null) {
                Error += "O endereço do cliente " + Nome + " não foi informado!";
            }
            if (ContaBancaria == null) {
                Error += "A conta bancaria do cliente " + Nome + " não foi informado!";
            }
            if (!String.IsNullOrEmpty(Error)) {
                throw new Exception(Error);
            }
        }
    }
}
