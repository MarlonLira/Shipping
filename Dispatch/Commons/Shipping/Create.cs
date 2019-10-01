using Dispatch.Commons.Banks;
using Library.Arquivos.CNAB240.Remessa;
using Library.Banks;
using Library.Commons;
using Library.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dispatch.Commons.Shipping
{
    public static class Create
    {
        public static StringBuilder Shipping(Empresa EmpresaCedente, List<Cliente> ClientesSacados, Bank CodigoBancario) {
            String File;
            StringBuilder Result;
            String[] FilePart;
            Int32 TotalRegCount = 0;
            
            try {
                EmpresaCedente.Verificar();
                Result = new StringBuilder();
                var Itau = new WriteShipping.Itau();
                var CNB240 = new RemessaCNAB240(EmpresaCedente);

                switch (CodigoBancario) {
                    case Bank.Itau: {
                            //Init Header File
                            File = Itau.WriteHeaderFile(CNB240);
                            foreach (Cliente FoundClient in ClientesSacados) {
                                FoundClient.Verificar();
                                CNB240 = new RemessaCNAB240(EmpresaCedente, FoundClient, 1);
                                //Init Header Allotment
                                File += "|" + Itau.WriteHeaderAllotment(CNB240);
                                foreach (Cobranca Cobranca in FoundClient.CobrancaAgendada) {
                                    Cobranca.Verificar();
                                    TotalRegCount++;
                                    CNB240.ClienteSacado.ValorAgendado = Cobranca.Valor;
                                    CNB240.ClienteSacado.DataCobranca = Cobranca.Data;
                                    CNB240.ClienteSacado.ValorMoeda = (Cobranca.Valor * Cobranca.PctIOF);

                                    //Details
                                    File += "|" + Itau.WriteHeaderDetails(CNB240);
                                }
                                //Close Header Allotment
                                File += "|" + Itau.WriteTrailerAllotment(CNB240);
                            }
                            CNB240.Registros = new Registro() {
                                TotalQtdLotes = ClientesSacados.Count,
                                TotalQtdRegs = 2 + (2 * ClientesSacados.Count) + TotalRegCount
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

        public static void TxtFile(StringBuilder Text, Banco Banco) {
            String Path;
            String Date;
            String FileName;
            StreamWriter File;

            try {
                Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Date = DateTime.Now.ToString("d").Replace("/", "");
                FileName = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", Banco.Codigo, "-", Banco.Nome, "_", Date, DateTime.Now.Ticks.ToString().Substring(1, 4), @"_HEADER", ".txt");
                File = new StreamWriter(Path + @"\" + FileName, true);
                File.Write(Text);
                Console.WriteLine("Arquivo foi gerado com sucesso, verifique a area de trabalho!");
                Console.WriteLine("Clique em qualquer tecla para continuar.");
                Console.ReadKey();
                File.Close();
            } catch {
                throw;
            }

        }
    }
}
