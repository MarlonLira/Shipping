using Dispatch.Commons.Banks;
using Library.Arquivos.CNAB240.Remessa;
using Library.Banks;
using Library.Commons;
using Library.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dispatch.Commons.Files
{
    public static class Create
    {
        public static StringBuilder Shipping(Empresa EmpresaCedente, List<Cliente> ClientesSacados, Bank CodigoBancario, Int32 Sequencial) {
            String File;
            StringBuilder Result;
            String[] FilePart;
            Int32 TotalRegCount = 0;
            
            try {
                EmpresaCedente.Verificar();
                Result = new StringBuilder();
                var Itau = new WriteShipping.Itau();
                var CNB240 = new RemessaCNAB240(EmpresaCedente, Sequencial);

                switch (CodigoBancario) {
                    case Bank.Itau: {
                            //Init Header File
                            File = Itau.WriteHeaderFile(CNB240);
                            foreach (Cliente FoundClient in ClientesSacados) {
                                FoundClient.Verificar();
                                CNB240 = new RemessaCNAB240(EmpresaCedente, FoundClient, Sequencial);
                                //CNB240.Registros = new Registro();
                                CNB240.Registros.SequencialLote++;
                                //Init Header Allotment
                                File += "|" + Itau.WriteHeaderAllotment(CNB240);
                                foreach (Cobranca Cobranca in FoundClient.CobrancaAgendada) {
                                    Cobranca.Verificar();
                                    CNB240.Registros.SequencialDetalhe++;
                                    TotalRegCount++;
                                    CNB240.ClienteSacado.ValorAgendado = Cobranca.Valor;
                                    CNB240.ClienteSacado.DataCobranca = Cobranca.Data.ToShortDateString();
                                    CNB240.ClienteSacado.ValorMoeda = (Cobranca.Valor * Cobranca.PctIOF);
                                    CNB240.ClienteSacado.NDocto = Cobranca.NDocto;

                                    //Details
                                    File += "|" + Itau.WriteDetailsAllotment(CNB240);
                                }
                                //Close Header Allotment
                                File += "|" + Itau.WriteTrailerAllotment(CNB240);
                            }
                            CNB240.Registros.TotalQtdLotes = ClientesSacados.Count;
                            CNB240.Registros.TotalQtdRegs = 2 + (2 * ClientesSacados.Count) + TotalRegCount;
                           
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

        public static StringBuilder Return(Empresa EmpresaCedente, List<Cliente> ClientesSacados, Bank CodigoBancario, Int32 Sequencial) {
            String File;
            StringBuilder Result;
            String[] FilePart;
            Int32 TotalRegCount = 0;

            try {
                EmpresaCedente.Verificar();
                Result = new StringBuilder();
                var Itau = new WriteReturn.Itau();
                var CNB240 = new RemessaCNAB240(EmpresaCedente, Sequencial);

                switch (CodigoBancario) {
                    case Bank.Itau: {
                            //Init Header File
                            File = Itau.WriteHeaderFile(CNB240);
                            foreach (Cliente FoundClient in ClientesSacados) {
                                FoundClient.Verificar();
                                CNB240 = new RemessaCNAB240(EmpresaCedente, FoundClient, Sequencial);
                                //CNB240.Registros = new Registro();
                                CNB240.Registros.SequencialLote++;
                                //Init Header Allotment
                                File += "|" + Itau.WriteHeaderAllotment(CNB240, "000102");
                                foreach (Cobranca Cobranca in FoundClient.CobrancaAgendada) {
                                    Cobranca.Verificar();
                                    CNB240.Registros.SequencialDetalhe++;
                                    TotalRegCount++;
                                    CNB240.ClienteSacado.ValorAgendado = Cobranca.Valor;
                                    CNB240.ClienteSacado.DataCobranca = Cobranca.Data.ToShortDateString();
                                    CNB240.ClienteSacado.ValorMoeda = (Cobranca.Valor * Cobranca.PctIOF);

                                    //Details
                                    File += "|" + Itau.WriteDetailsAllotment(CNB240, "0201IH");
                                }
                                //Close Header Allotment
                                File += "|" + Itau.WriteTrailerAllotment(CNB240, "0201IH");
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

        public static String TxtFile(StringBuilder Text, Banco Banco, Boolean IsRemessa = true) {
            String Path;
            String Date;
            String FileName;
            StreamWriter File;

            try {
                Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Date = DateTime.Now.ToString("d").Replace("/", "");
                if(IsRemessa)
                    FileName = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", Banco.Codigo, "-", Banco.Nome, "_", Date, DateTime.Now.Ticks, @"_HEADER", ".txt");
                else
                    FileName = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", Banco.Codigo, "-", Banco.Nome, "_", Date, DateTime.Now.Ticks, @"_RETURN", ".txt");

                File = new StreamWriter(Path + @"\" + FileName, true);
                File.Write(Text);
                Console.WriteLine("Arquivo foi gerado com sucesso, verifique a area de trabalho!");
                Console.WriteLine("Clique em qualquer tecla para continuar.");
                Console.ReadKey();
                File.Close();
            } catch {
                throw;
            }
            return (Path + @"\" + FileName);
        }
    }
}
