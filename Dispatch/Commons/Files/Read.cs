using Library.Banks;
using Library.Commons;
using Library.Files.CNAB240.Retorno;
using System;
using System.Collections.Generic;
using static Library.Commons.Empresa;

namespace Dispatch.Commons.Files
{
    public static class Read {
        public static RetornoCNAB240 Return(String Path) {
            RetornoCNAB240 Return = new RetornoCNAB240();
            Int32 Count = -1;
            Object Identity;
            String[] Lines;
            try {
                Lines = (!String.IsNullOrEmpty(Path)
                    ? System.IO.File.ReadAllLines(Path)
                    : throw new Exception("O caminho do arquivo não foi informado ou está incorreto!"));

                foreach (String FoundLine in Lines) {
                    Identity = Convert.ToInt32(FoundLine.RetriveOnLine(8, 8));
                    if ((IsFile)Identity == IsFile.HeaderAllotment) { Count++; };
                    Return = RetriveLine(FoundLine, Return, Count);
                }

            } catch {
                throw;
            }

            return Return;
        }

        private static RetornoCNAB240 RetriveLine(String Line, RetornoCNAB240 Return, Int32 Count) {
            Object Identity;
            RetornoCNAB240 Result = (Return != null
                ? Return
                : throw new Exception("O retorno não pode ser nulo!"));
            Identity = Convert.ToInt32(Line.RetriveOnLine(8, 8));
            switch ((IsFile)Identity) {
                case IsFile.HeaderFile: {
                        Result.HeaderFile.Banco = new Itau(false);
                        Result.HeaderFile.Banco.Codigo = Line.RetriveOnLine(1, 3); // CODIGO BANCARIO
                        Result.HeaderFile.TipoInscricaoEmp = Convert.ToInt32(Line.RetriveOnLine(18, 18)); // TIPO DE INSCRIÇÃO DA EMPRESA | CPF = '1' | CNPJ =  '2'
                        Result.HeaderFile.Empresa.CNPJ = Line.RetriveOnLine(19, 32); // NÚMERO DO CNPJ/CPF DA EMPRESA
                        Result.HeaderFile.Empresa.Convenio = Line.RetriveOnLine(33, 45).Trim(); // CÓDIGO DO CONVÊNIO NO BANCO
                        Result.HeaderFile.Empresa.ContaBancaria.AgenciaBancaria.Agencia = Line.RetriveOnLine(54, 57); // AGENCIA REFERENTE CONVÊNIO ASSINADO 
                        Result.HeaderFile.Empresa.ContaBancaria.Conta = Line.RetriveOnLine(66, 70); // NÚMERO DA C/C DO CLIENTE
                        Result.HeaderFile.Empresa.ContaBancaria.Digito = Line.RetriveOnLine(72, 72); // DAC (Dígito de Auto Conferência) DA AGÊNCIA/ CONTA.
                        Result.HeaderFile.Empresa.Nome = Line.RetriveOnLine(73, 102); // NOME DA EMPRESA
                        Result.HeaderFile.Banco.Nome = Line.RetriveOnLine(103, 132).Trim(); // NOME DO BANCO
                        Result.HeaderFile.CodigoRR = Line.RetriveOnLine(143, 143); //  CÓDIGO REMESSA = 1/RETORNO = 2
                        Result.HeaderFile.DataGeracao = Line.RetriveOnLine(144, 151).FormatDate(); //  DATA DE GERAÇÃO DO ARQUIVO
                        Result.HeaderFile.HoraGeracao = Line.RetriveOnLine(152, 157).FormatHour(); // HORA DE GERAÇÃO DO ARQUIVO 
                        Result.HeaderFile.SequencialArquivo = Line.RetriveOnLine(158, 163); // NR. SEQUENCIAL DO ARQUIVO 
                        Result.HeaderFile.VLayout = Line.RetriveOnLine(164, 166); // NR. DA VERSÃO DO LAYOUT

                        break;
                    }
                case IsFile.HeaderAllotment: {
                        HeaderAllotment HeaderAllotment = new HeaderAllotment();
                        HeaderAllotment.Banco = new Itau(false);
                        Ocorrencias Ocorrencia = new Ocorrencias();

                        HeaderAllotment.Banco.Codigo = Line.RetriveOnLine(1, 3); // CODIGO BANCARIO
                        HeaderAllotment.TipoInscricaoEmp = Convert.ToInt32(Line.RetriveOnLine(18, 18)); // TIPO DE INSCRIÇÃO DA EMPRESA | CPF = '1' | CNPJ =  '2'
                        HeaderAllotment.Empresa.CNPJ = Line.RetriveOnLine(19, 32); // NÚMERO DO CNPJ/CPF DA EMPRESA
                        HeaderAllotment.Empresa.Convenio = Line.RetriveOnLine(33, 45).Trim(); // CÓDIGO DO CONVÊNIO NO BANCO
                        HeaderAllotment.Empresa.ContaBancaria.AgenciaBancaria.Agencia = Line.RetriveOnLine(54, 57); // AGENCIA REFERENTE CONVÊNIO ASSINADO 
                        HeaderAllotment.Empresa.ContaBancaria.Conta = Line.RetriveOnLine(66, 70); // NÚMERO DA C/C DO CLIENTE
                        HeaderAllotment.Empresa.ContaBancaria.Digito = Line.RetriveOnLine(72, 72); // DAC (Dígito de Auto Conferência) DA AGÊNCIA/ CONTA.
                        HeaderAllotment.Empresa.Nome = Line.RetriveOnLine(73, 102); // NOME DA EMPRESA
                        HeaderAllotment.Empresa.Endereco.Nome = Line.RetriveOnLine(143, 172).Trim(); // ENDEREÇO EMPRESA NOME DA RUA, AV, PÇA, ETC...
                        HeaderAllotment.Empresa.Endereco.Numero = Convert.ToInt32(Line.RetriveOnLine(173, 177)); //  NÚMERO DO LOCAL
                        HeaderAllotment.Empresa.Endereco.Tipo = Line.RetriveOnLine(178, 192).Trim(); //  CASA, APTO, SALA, ETC... 
                        HeaderAllotment.Empresa.Endereco.Cidade = Line.RetriveOnLine(193, 212).Trim(); // NOME DA CIDADE
                        HeaderAllotment.Empresa.Endereco.CEP = Line.RetriveOnLine(213, 220).Trim(); // CEP
                        HeaderAllotment.Empresa.Endereco.EstadoSigla = Line.RetriveOnLine(221, 222).Trim(); // SIGLA DO ESTADO 
                        HeaderAllotment.Ocorrencias = Ocorrencia.ReturnOccurrence(Line.RetriveOnLine(231, 240)); // CÓDIGO OCORRÊNCIAS
                        Result.Allotment.Add(new Allotment() { HeaderAllotment = HeaderAllotment });

                        break;
                    }
                case IsFile.DetailsAllotment: {
                        DetailsAllotment DetailsAllotment = new DetailsAllotment();
                        DetailsAllotment.Banco = new Itau(false);

                        Ocorrencias Ocorrencia = new Ocorrencias();

                        DetailsAllotment.Banco.Codigo = Line.RetriveOnLine(1, 3); // CODIGO BANCARIO
                        DetailsAllotment.SequencialDetalhe = Line.RetriveOnLine(9, 13); // Nº SEQUENCIAL REGISTRO NO LOTE
                        DetailsAllotment.CodigoIM = Line.RetriveOnLine(15, 17);// 000 = inclusão de debito | 999 = exlusão de debito                        
                        DetailsAllotment.Cliente.ContaBancaria.AgenciaBancaria.Agencia = Line.RetriveOnLine(25, 28); // Nº. AGÊNCIA DEBITADA
                        DetailsAllotment.Cliente.ContaBancaria.Conta = Line.RetriveOnLine(37, 41); // NR. DA CONTA DEBITADA
                        DetailsAllotment.Cliente.ContaBancaria.Digito = Line.RetriveOnLine(43, 43); // DIGITO VERIFICADOR DA AG/CONTA
                        DetailsAllotment.Cliente.Nome = Line.RetriveOnLine(44, 73).Trim(); // NOME DO DEBITADO
                        DetailsAllotment.Cliente.DataCobranca = Line.RetriveOnLine(94, 101).FormatDate(); // DATA PARA O LANÇAMENTO DO DÉBITO
                        DetailsAllotment.Banco.Moeda = Line.RetriveOnLine(102, 104); // TIPO DA MOEDA
                        DetailsAllotment.Cliente.ValorMoeda = Line.RetriveOnLine(105, 119).FormatToMoney(5); // QUANTIDADE DA MOEDA OU IOF
                        DetailsAllotment.Cliente.ValorAgendado = Line.RetriveOnLine(120, 134).FormatToMoney(2); // VALOR DO LANÇAMENTO PARA DÉBITO
                        DetailsAllotment.DocumentoBanco = Line.RetriveOnLine(135, 154).Trim(); // NR. DO DOCUM. ATRIBUÍDO PELO BANCO
                        DetailsAllotment.DataLancto = Line.RetriveOnLine(155, 162).FormatDate(); // DATA REAL DA EFETIVAÇÃO DO LANÇTO.
                        DetailsAllotment.Empresa.Mora = (MoraTipo) Convert.ToInt32(Line.RetriveOnLine(178, 179)); //TIPO DO ENCARGO POR DIA DE ATRASO
                        DetailsAllotment.Empresa.Juros = Convert.ToSingle(Line.RetriveOnLine(180, 196)); // VALOR DO ENCARGO P/ DIA DE ATRASO
                        DetailsAllotment.Empresa.IdentificadorExtrato = Line.RetriveOnLine(197, 212).Trim(); // INFORMAÇÃO COMPL. P/ HISTÓRICO C/C
                        DetailsAllotment.Cliente.CPF = Line.RetriveOnLine(217, 230).Trim(); // Nº DE INSCRIÇÃO DO DEBITADO (CPF/CNPJ)
                        DetailsAllotment.Ocorrencias =  new List<string>() { Ocorrencia.ReturnOccurrence(Line.RetriveOnLine(231, 240)) }; // CÓDIGO OCORRÊNCIAS
                        Result.Allotment[Count].DetailsAllotment.Add(DetailsAllotment);

                        break;
                    }
                case IsFile.TrailerAllotment: {
                        TrailerAllotment TrailerAllotment = new TrailerAllotment();
                        TrailerAllotment.Banco = new Itau(false);
                        Ocorrencias Ocorrencia = new Ocorrencias();

                        TrailerAllotment.Banco.Codigo = Line.RetriveOnLine(1, 3); // CODIGO BANCARIO
                        TrailerAllotment.SequencialLote = Line.RetriveOnLine(4,7); // LOTE IDENTIFICAÇÃO DE SERVIÇO
                        TrailerAllotment.Registro.TotalQtdLotes = Convert.ToInt32(Line.RetriveOnLine(18, 23)); //QTDE REGISTROS DO LOTE
                        TrailerAllotment.ValorDebitoTotal = Line.RetriveOnLine(24, 41).FormatToMoney(2); //SOMA VALOR DOS DÉBITOS DO LOTE
                        TrailerAllotment.ValorMoedaTotal = Line.RetriveOnLine(42, 59).FormatToMoney(5); //SOMATÓRIA DA QTDE DE MOEDAS DO LOTE
                        TrailerAllotment.Ocorrencias = Ocorrencia.ReturnOccurrence(Line.RetriveOnLine(231, 240)); // CÓDIGO OCORRÊNCIAS
                        Result.Allotment[Count].TrailerAllotment = TrailerAllotment;

                        break;
                    }
                case IsFile.TrailerFile: {
                        
                        Result.TrailerFile.Banco = new Itau(false);
                        Result.TrailerFile.Banco.Codigo = Line.RetriveOnLine(1, 3); // CÓDIGO BANCO NA COMPENSAÇÃO
                        Result.TrailerFile.SequencialLote = Line.RetriveOnLine(4, 7); // LOTE IDENTIFICAÇÃO DE SERVIÇO 
                        Result.TrailerFile.Registro.TotalQtdLotes = Convert.ToInt32(Line.RetriveOnLine(18, 23)); // QTDE LOTES DO ARQUIVO 
                        Result.TrailerFile.Registro.TotalQtdRegs = Convert.ToInt32(Line.RetriveOnLine(24, 29)); // QTDE REGISTROS DO ARQUIVO

                        break;
                    }
            }

            return Result;
        }
    }

    public static class Retrive{
        public static String RetriveOnLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
            String Result = Convert.ToString(ContentEdit);
            Int32 Start = FromLine - 1;
            Int32 SizeOfLine = ToLine - Start;
            Result = Result.Substring(Start, SizeOfLine);
            return Result;
        }

        public static String RemoveAndResize(this Object ContentEdit, Int32 Size, Boolean IsNumeric = false) {
            String Result = Convert.ToString(ContentEdit);
            String Identity = "";
            Int32 Count = 0;
            if (Result.Length > Size) {

                switch (IsNumeric) {
                    case true: {
                            while (Result.Length > Size) {
                                Identity = Result.Substring(Count, 1);
                                if (Convert.ToInt32(Identity) == 0) {
                                    Result = Result.Substring(Count, Size);
                                }
                                Count++;
                            }
                            break;
                        }
                    case false: {

                            break;
                        }

                }

            }
            return Result;
        }
    }

    public enum IsFile
    {
        HeaderFile = 0,
        HeaderAllotment = 1,
        DetailsAllotment = 3,
        TrailerAllotment = 5,
        TrailerFile = 9
    }

}
