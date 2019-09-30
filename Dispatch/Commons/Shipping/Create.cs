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
            String File;
            StringBuilder Result;
            String[] FilePart; 
            
            try {
                Result = new StringBuilder();
                var Itau = new WriteShipping.Itau();
                var CNB240 = new RemessaCNAB240(EmpresaCedente);

                switch (CodigoBancario) {
                    case Bank.Itau: {
                            //Init Header File
                            File = Itau.WriteHeaderFile(CNB240);
                            foreach (Cliente FoundClient in ClientesSacados) {
                                CNB240 = new RemessaCNAB240(EmpresaCedente, FoundClient, 10);
                                //Init Header Allotment
                                File += "|" + Itau.WriteHeaderAllotment(CNB240);
                                foreach (Cobranca Cobranca in FoundClient.CobrancaAgendada) {
                                    if (Cobranca.Data == default(DateTime)) {
                                        throw new Exception("Erro: A data da cobrança do cliente " + FoundClient.Nome + " não foi informada!");
                                    }
                                    CNB240.ClienteSacado.ValorAgendado = Cobranca.Valor;
                                    CNB240.ClienteSacado.DataCobranca = Cobranca.Data;
                                    //Details
                                    File += "|" + Itau.WriteHeaderDetails(CNB240);
                                }
                                //Close Header Allotment
                                File += "|" + Itau.WriteTrailerAllotment(CNB240);
                            }
                            CNB240.Registros = new Registro() {
                                TotalQtdLotes = ClientesSacados.Count,
                                TotalQtdRegs = 2 + (2 * ClientesSacados.Count) + (2 * ClientesSacados.Count)
                            };
                            //Close Header File
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
