using Library.Banks;
using Library.Commons;
using Library.Files.CNAB240.Retorno;
using System;

namespace Dispatch.Commons.Files
{
    public static class Read {
        public static RetornoCNAB240 Return(String Path) {
            RetornoCNAB240 Return = new RetornoCNAB240();
            String[] Lines;
            try {
                Lines = (!String.IsNullOrEmpty(Path)
                    ? System.IO.File.ReadAllLines(Path)
                    : throw new Exception("O caminho do arquivo não foi informado ou está incorreto!"));

                foreach (String FoundLine in Lines) {
                    Return = RetriveLine(FoundLine, Return);
                }

            } catch {
                throw;
            }

            return Return;
        }

        private static RetornoCNAB240 RetriveLine(String Line, RetornoCNAB240 Return) {
            Object Identity;
            RetornoCNAB240 Result = (Return != null
                ? Return
                : throw new Exception("O retorno não pode ser nulo!"));

            Identity = Convert.ToInt32(Line.RetriveOnLine(8, 8));
            switch ((IsFile)Identity) {
                case IsFile.HeaderFile: {
                        Result.HeaderFile = new HeaderFile();
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
                        Result.HeaderFile.DataGeracao = Line.RetriveOnLine(144, 151); //  DATA DE GERAÇÃO DO ARQUIVO
                        Result.HeaderFile.HoraGeracao = Line.RetriveOnLine(152, 157); // HORA DE GERAÇÃO DO ARQUIVO 
                        Result.HeaderFile.SequencialArquivo = Line.RetriveOnLine(158, 163); // NR. SEQUENCIAL DO ARQUIVO 
                        Result.HeaderFile.VLayout = Line.RetriveOnLine(164, 166); // NR. DA VERSÃO DO LAYOUT

                        break;
                    }
                case IsFile.HeaderAllotment: {
                        Result.HeaderAllotment = new HeaderAllotment();
                        Result.HeaderAllotment.Banco = new Itau(false);
                        Result.HeaderAllotment.Banco.Codigo = Line.RetriveOnLine(1, 3); // CODIGO BANCARIO
                        Result.HeaderAllotment.TipoInscricaoEmp = Convert.ToInt32(Line.RetriveOnLine(18, 18)); // TIPO DE INSCRIÇÃO DA EMPRESA | CPF = '1' | CNPJ =  '2'
                        Result.HeaderAllotment.Empresa.CNPJ = Line.RetriveOnLine(19, 32); // NÚMERO DO CNPJ/CPF DA EMPRESA
                        Result.HeaderAllotment.Empresa.Convenio = Line.RetriveOnLine(33, 45).Trim(); // CÓDIGO DO CONVÊNIO NO BANCO
                        Result.HeaderAllotment.Empresa.ContaBancaria.AgenciaBancaria.Agencia = Line.RetriveOnLine(54, 57); // AGENCIA REFERENTE CONVÊNIO ASSINADO 
                        Result.HeaderAllotment.Empresa.ContaBancaria.Conta = Line.RetriveOnLine(66, 70); // NÚMERO DA C/C DO CLIENTE
                        Result.HeaderAllotment.Empresa.ContaBancaria.Digito = Line.RetriveOnLine(72, 72); // DAC (Dígito de Auto Conferência) DA AGÊNCIA/ CONTA.
                        Result.HeaderAllotment.Empresa.Nome = Line.RetriveOnLine(73, 102); // NOME DA EMPRESA
                        Result.HeaderAllotment.Banco.Nome = Line.RetriveOnLine(103, 132).Trim(); // NOME DO BANCO
                        Result.HeaderAllotment.Empresa.Endereco.Nome = Line.RetriveOnLine(143, 172).Trim(); // ENDEREÇO EMPRESA NOME DA RUA, AV, PÇA, ETC...
                        Result.HeaderAllotment.Empresa.Endereco.Numero = Convert.ToInt32(Line.RetriveOnLine(173, 177)); //  NÚMERO DO LOCAL
                        Result.HeaderAllotment.Empresa.Endereco.Tipo = Line.RetriveOnLine(178, 192).Trim(); //  CASA, APTO, SALA, ETC... 
                        Result.HeaderAllotment.Empresa.Endereco.Cidade = Line.RetriveOnLine(193, 212).Trim(); // NOME DA CIDADE
                        Result.HeaderAllotment.Empresa.Endereco.CEP = Line.RetriveOnLine(213, 220).Trim(); // CEP
                        Result.HeaderAllotment.Empresa.Endereco.EstadoSigla = Line.RetriveOnLine(221, 222).Trim(); // SIGLA DO ESTADO 
                        Result.HeaderAllotment.Ocorrencias = Line.RetriveOnLine(231, 240).Trim(); // CÓDIGO OCORRÊNCIAS

                        break;
                    }
                case IsFile.DetailsAllotment: {

                        break;
                    }
                case IsFile.TrailerAllotment: {

                        break;
                    }
                case IsFile.TrailerFile: {

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
