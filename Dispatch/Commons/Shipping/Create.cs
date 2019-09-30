using Dispatch.Commons.Banks;
using Library.Arquivos.CNAB240.Remessa;
using Library.Banks;
using Library.Commons;
using Library.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dispatch.Commons.Shipping
{
    public static class Create
    {
        public static StringBuilder Shipping(Empresa EmpresaCedente, List<Cliente> ClientesSacados, Bank CodigoBancario) {
            String File = "";
            StringBuilder Result;
            String[] FilePart; 
            
            try {
                Result = new StringBuilder();
                var Itau = new WriteShipping.Itau();
                var CNB240 = new RemessaCNAB240(EmpresaCedente);

                switch (CodigoBancario) {
                    case Bank.Itau: {
                            File = Itau.WriteHeaderFile(CNB240);
                            foreach (Cliente FoundClient in ClientesSacados) {
                                CNB240 = new RemessaCNAB240(EmpresaCedente, FoundClient, 10);
                                foreach (Cliente.Cobranca Cobranca in FoundClient.CobrancaAgendada) {
                                    CNB240.ClienteSacado.ValorAgendado = Cobranca.Valor;
                                    File += "|" + Itau.WriteHeaderAllotment(CNB240);
                                    File += "|" + Itau.WriteHeaderDetails(CNB240);
                                    File += "|" + Itau.WriteTrailerAllotment(CNB240);
                                }

                            }
                            CNB240.Registros = new Registro() {
                                TotalQtdLotes = ClientesSacados.Count,
                                TotalQtdRegs = 2 + (2 * ClientesSacados.Count) + (2 * ClientesSacados.Count)
                            };
                            File += "|" + Itau.WriteTrailerFile(CNB240);

                            FilePart = File.Split('|');

                            foreach (String FoundFile in FilePart) {
                                Result.AppendLine(FoundFile);
                            }
                            break;
                        }
                    case Bank.Bradesco: {
                            throw new Exception("O banco ainda não foi implementado!");
                            break;
                        }
                    case Bank.Brasil: {
                            throw new Exception("O banco ainda não foi implementado!");
                            break;
                        }
                    case Bank.Caixa: {
                            throw new Exception("O banco ainda não foi implementado!");
                            break;
                        }
                    case Bank.Santander: {
                            throw new Exception("O banco ainda não foi implementado!");
                            break;
                        }
                    default: {
                            throw new Exception("O banco não foi encontrado!");
                            break;
                        }

                }
            } catch {
                throw;
            }

            return Result;
        }
    }
}
