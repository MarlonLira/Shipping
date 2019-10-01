using System;
using Library.Arquivos.CNAB240.Remessa;
using static Library.Commons.Empresa;

namespace Library.Files
{
    public class WriteShipping {

        public class Itau {

            Banks.Itau BancoItau = new Banks.Itau();
            String DataAtual = DateTime.UtcNow.AddHours(-3).ToShortDateString();
            String HoraAtual = DateTime.UtcNow.AddHours(-3).ToLongTimeString();

            public String WriteHeaderFile(RemessaCNAB240 Header) {
                String Result;
                String EmpresaNome = Header.EmpresaCedente.Nome;

                if (EmpresaNome.Length > 30) {
                    EmpresaNome = EmpresaNome.Substring(0, 30);
                }

                var File = new String(' ', 240);

                try {

                    File = File.WriteInLine(1, 3, "341"); // CODIGO BANCARIO
                    File = File.AddZeroRightLine(4, 7); // ZEROS
                    File = File.AddZeroRightLine(8, 8); // ZERO
                    File = File.RightEmptyLine(9, 17); // BRANCOS
                    File = File.WriteInLine(18, 18, "2"); // TIPO DE INSCRIÇÃO DA EMPRESA | CPF = '1' | CNPJ =  '2'
                    File = File.WriteInLine(19, 32, Header.EmpresaCedente.CNPJ); //  NÚMERO DO CNPJ/CPF DA EMPRESA
                    File = File.WriteInLine(33, 45, Header.EmpresaCedente.Codigo.AddZeroLeftLine(33, 45)); // CÓDIGO DO CONVÊNIO NO BANCO 
                    File = File.RightEmptyLine(46, 52); // BRANCOS 
                    File = File.AddZeroRightLine(53, 53); // ZERO
                    File = File.WriteInLine(54, 57, Header.EmpresaCedente.ContaBancaria.AgenciaBancaria.Agencia); // AGENCIA REFERENTE CONVÊNIO ASSINADO 
                    File = File.RightEmptyLine(58, 58); // BRANCOS
                    File = File.AddZeroRightLine(59, 65); // ZEROS
                    File = File.WriteInLine(66, 70, Header.EmpresaCedente.ContaBancaria.Conta); // NÚMERO DA C/C DO CLIENTE
                    File = File.RightEmptyLine(71, 71); // BRANCOS
                    File = File.WriteInLine(72, 72, Header.EmpresaCedente.ContaBancaria.Digito); // DAC (Dígito de Auto Conferência) DA AGÊNCIA/ CONTA.
                    File = File.WriteInLine(73, 102, Header.EmpresaCedente.Nome.AddEmptyLine(73, 102)); // NOME DA EMPRESA
                    File = File.WriteInLine(103, 132, "BANCO ITAU".AddEmptyLine(103, 132)); // NOME DO BANCO
                    File = File.RightEmptyLine(133, 142); // BRANCOS
                    File = File.WriteInLine(143, 143, "1"); //  CÓDIGO REMESSA = 1/RETORNO = 2
                    File = File.WriteInLine(144, 151, DataAtual.Replace("/", "")); //  DATA DE GERAÇÃO DO ARQUIVO
                    File = File.WriteInLine(152, 157, HoraAtual.Replace(":", "")); // HORA DE GERAÇÃO DO ARQUIVO 
                    File = File.WriteInLine(158, 163, Convert.ToString(Header.SequencialNsa).AddZeroLeftLine(158, 163)); // NR. SEQUENCIAL DO ARQUIVO  
                    File = File.WriteInLine(164, 166, "040"); // NR. DA VERSÃO DO LAYOUT
                    File = File.AddZeroRightLine(167, 171); // DENSIDADE DE GRAVAÇÃO DO ARQUIVO 
                    File = File.RightEmptyLine(172, 191); // PARA USO RESERVADO DO BANCO 
                    File = File.RightEmptyLine(192, 240); // BRANCOS

                    Result = File;

                } catch {
                    throw;
                }
                return Result;
            }

            public String WriteHeaderAllotment(RemessaCNAB240 Header) {
                String Result;
                String EmpresaNome = Header.EmpresaCedente.Nome;

                if (EmpresaNome.Length > 30) {
                    EmpresaNome = EmpresaNome.Substring(0, 30);
                }

                var File = new String(' ', 240);

                try {

                    File = File.WriteInLine(1, 3, "341"); // CODIGO BANCARIO
                    File = File.AddZeroRightLine(4, 7); // LOTE IDENTIFICAÇÃO DE SERVIÇO
                    File = File.WriteInLine(8, 8, "1"); // REGISTRO DO HEADER DO LOTE
                    File = File.WriteInLine(9, 9, "D"); // TIPO DA OPERAÇÃO
                    File = File.WriteInLine(10, 11, "05"); // FORMA DE LANÇAMENTO
                    File = File.WriteInLine(12, 13, "50"); // Nº DA VERSÃO DO LAYOUT 
                    File = File.WriteInLine(14, 16, "030"); // Nº DA VERSÃO DO LAYOUT 
                    File = File.RightEmptyLine(17, 17); // BRANCOS 
                    File = File.WriteInLine(18, 18, "2"); // TIPO DE INSCRIÇÃO DA EMPRESA | CPF = '1' | CNPJ =  '2'
                    File = File.WriteInLine(19, 32, Header.EmpresaCedente.CNPJ); // NÚMERO DO CNPJ/CPF DA EMPRESA
                    File = File.WriteInLine(33, 45, Header.EmpresaCedente.Codigo.AddZeroLeftLine(33, 45)); // CÓDIGO DO CONVÊNIO NO BANCO 
                    File = File.RightEmptyLine(46, 52); // BRANCOS 
                    File = File.AddZeroRightLine(53, 53); // ZERO
                    File = File.WriteInLine(54, 57, Header.EmpresaCedente.ContaBancaria.AgenciaBancaria.Agencia); // NÚMERO AGÊNCIA MANTEDORA DA CONTA
                    File = File.RightEmptyLine(58, 58); // BRANCOS
                    File = File.AddZeroRightLine(59, 65); // ZEROS
                    File = File.WriteInLine(66, 70, Header.EmpresaCedente.ContaBancaria.Conta); // NÚMERO DA C/C DO CLIENTE
                    File = File.RightEmptyLine(71, 71); // BRANCOS
                    File = File.WriteInLine(72, 72, Header.EmpresaCedente.ContaBancaria.Digito); // DAC (Dígito de Auto Conferência) DA AGÊNCIA/ CONTA.
                    File = File.WriteInLine(73, 102, Header.EmpresaCedente.Nome.AddEmptyLine(73, 102)); // NOME DA EMPRESA
                    File = File.RightEmptyLine(103, 142); // BRANCOS
                    File = File.WriteInLine(143, 172, Header.EmpresaCedente.Endereco.Nome.AddEmptyLine(143, 172)); // ENDEREÇO EMPRESA NOME DA RUA, AV, PÇA, ETC...
                    File = File.WriteInLine(173, 177, Header.EmpresaCedente.Endereco.Numero.AddEmptyLine(173, 177)); //  NÚMERO DO LOCAL
                    File = File.WriteInLine(178, 192, Header.EmpresaCedente.Endereco.Tipo.AddEmptyLine(178, 192)); //  CASA, APTO, SALA, ETC... 
                    File = File.WriteInLine(193, 212, Header.EmpresaCedente.Endereco.Cidade.AddEmptyLine(193, 212)); // NOME DA CIDADE
                    File = File.WriteInLine(213, 220, Header.EmpresaCedente.Endereco.CEP.AddEmptyLine(213, 220)); // CEP
                    File = File.WriteInLine(221, 222, Header.EmpresaCedente.Endereco.EstadoSigla); // SIGLA DO ESTADO 
                    File = File.LeftEmptyLine(223, 230); // BRANCOS
                    File = File.LeftEmptyLine(231, 240); // BRANCOS

                    Result = File;

                } catch {
                    throw;
                }
                return Result;
            }

            public String WriteHeaderDetails(RemessaCNAB240 Header) {
                String Result;
                String EmpresaNome = Header.EmpresaCedente.Nome;

                if (EmpresaNome.Length > 30) {
                    EmpresaNome = EmpresaNome.Substring(0, 30);
                }

                var File = new String(' ', 240);

                try {

                    File = File.WriteInLine(1, 3, "341"); // CÓDIGO BANCO NA COMPENSAÇÃO
                    File = File.WriteInLine(4, 7, "0001"); // LOTE IDENTIFICAÇÃO DE SERVIÇO
                    File = File.WriteInLine(8, 8, "3"); // REGISTRO DETALHE DE LOTE
                    File = File.WriteInLine(9, 13, "00001"); // Nº SEQUENCIAL REGISTRO NO LOTE
                    File = File.WriteInLine(14, 14, "A"); // CÓDIGO SEGMENTO REG. DETALHE 
                    File = File.WriteInLine(15, 17, "000"); // CÓDIGO DA INSTRUÇÃO PARA MOVIMENTO | 000 = inclusão de debito | 999 = exlusão de debito
                    File = File.WriteInLine(18, 20, "000"); // CÓDIGO DA CÂMARA DE COMPENSAÇÃO
                    File = File.WriteInLine(21, 23, "341"); // CÓDIGO DO BANCO
                    File = File.AddZeroRightLine(24, 24); // COMPLEMENTO DE REGISTROS
                    File = File.WriteInLine(25, 28, Header.ClienteSacado.ContaBancaria.AgenciaBancaria.Agencia); // Nº. AGÊNCIA DEBITADA
                    File = File.RightEmptyLine(29, 29); // COMPLEMENTO DE REGISTROS | BRANCOS
                    File = File.AddZeroRightLine(30, 36); // COMPLEMENTO DE REGISTROS | ZEROS
                    File = File.WriteInLine(37, 41, Header.ClienteSacado.ContaBancaria.Conta); // NR. DA CONTA DEBITADA
                    File = File.RightEmptyLine(42, 42); // COMPLEMENTO DE REGISTROS
                    File = File.WriteInLine(43, 43, Header.ClienteSacado.ContaBancaria.Digito); // DIGITO VERIFICADOR DA AG/CONTA
                    File = File.WriteInLine(44, 73, Header.ClienteSacado.Nome.AddEmptyLine(44, 73)); // NOME DO DEBITADO
                    File = File.LeftEmptyLine(74, 88); // NR. DO DOCUM. ATRIBUÍDO P/EMPRESA 
                    File = File.RightEmptyLine(89, 93); // COMPLENTO DE REGISTROS | BRANCOS
                    File = File.WriteInLine(94, 101, Header.ClienteSacado.DataCobranca.ToShortDateString().Replace("/", "")) ; // DATA PARA O LANÇAMENTO DO DÉBITO 
                    File = File.WriteInLine(102, 104, BancoItau.Moeda); // TIPO DA MOEDA
                    File = File.WriteInLine(105, 119, Header.ClienteSacado.ValorMoeda.FormatValuesInReal(10, 5)); // QUANTIDADE DA MOEDA OU IOF | IOF
                    File = File.WriteInLine(120, 134, Header.ClienteSacado.ValorAgendado.FormatValuesInReal(13, 2)); // VALOR DO LANÇAMENTO PARA DÉBITO
                    File = File.RightEmptyLine(135, 154); // NR. DO DOCUM. ATRIBUÍDO PELO BANCO
                    File = File.RightEmptyLine(155, 162); //  DATA REAL DA EFETIVAÇÃO DO LANÇTO. 
                    File = File.RightEmptyLine(163, 177); // VALOR REAL DA EFETIVAÇÃO DO LANÇTO.

                    switch (Header.EmpresaCedente.Mora) {
                        case MoraTipo.Isento: {
                                File = File.WriteInLine(178, 179, "00"); // TIPO DO ENCARGO POR DIA DE ATRASO | 00 = isento | 01 = juros simples | 03 = IDA (Importância por dia de atraso)
                                File = File.WriteInLine(180, 196, "00000000000000000"); // VALOR DO ENCARGO P/ DIA DE ATRASO
                                break;
                            }
                        case MoraTipo.JurosSimples: {
                                File = File.WriteInLine(178, 179, "01"); // TIPO DO ENCARGO POR DIA DE ATRASO | 00 = isento | 01 = juros simples | 03 = IDA (Importância por dia de atraso)
                                File = File.WriteInLine(180, 196, Header.EmpresaCedente.Juros.FormatValuesInReal(12,5)); // VALOR DO ENCARGO P/ DIA DE ATRASO
                                break;
                            }
                        case MoraTipo.IDA: {
                                File = File.WriteInLine(178, 179, "03"); // TIPO DO ENCARGO POR DIA DE ATRASO | 00 = isento | 01 = juros simples | 03 = IDA (Importância por dia de atraso)
                                File = File.WriteInLine(180, 196, Header.EmpresaCedente.ValorIDA.FormatValuesInReal(15,2)); // VALOR DO ENCARGO P/ DIA DE ATRASO
                                break;
                            }

                        default:
                            throw new Exception("Falta informar o Mora.");
                    }

                    File = File.WriteInLine(197, 212, "Deb Autor".AddEmptyLine(197, 212)); // INFORMAÇÃO COMPL. P/ HISTÓRICO C/C -->Alterar<--
                    File = File.RightEmptyLine(213, 216); // COMPLEMENTO DE REGISTRO | BRANCO
                    File = File.WriteInLine(217, 230, Header.ClienteSacado.CPF.AddEmptyLine(217, 230)); // Nº DE INSCRIÇÃO DO DEBITADO (CPF/CNPJ)
                    File = File.RightEmptyLine(231, 240); // CÓDIGO DAS OCORRÊNCIAS P/ RETORNO | BRANCOS

                    Result = File;

                } catch {
                    throw;
                }

                return Result;
            }

            public String WriteTrailerAllotment(RemessaCNAB240 Header) {
                String Result;
                String EmpresaNome = Header.EmpresaCedente.Nome;

                if (EmpresaNome.Length > 30) {
                    EmpresaNome = EmpresaNome.Substring(0, 30);
                }

                var File = new String(' ', 240);

                try {

                    File = File.WriteInLine(1, 3, "341"); // CÓDIGO BANCO NA COMPENSAÇÃO
                    File = File.WriteInLine(4, 7, "0001"); // LOTE IDENTIFICAÇÃO DE SERVIÇO
                    File = File.WriteInLine(8, 8, "5"); // REGISTRO DETALHE DE LOTE
                    File = File.RightEmptyLine(9, 17); // COMPLEMENTO | BRANCOS
                    File = File.WriteInLine(18, 23, Header.ClienteSacado.QtdRegsLote.AddZeroLeftLine(18,23)); // QTDE REGISTROS DO LOTE
                    File = File.WriteInLine(24, 41, Header.ClienteSacado.ValorTotal.FormatValuesInReal(16,2).AddZeroLeftLine(24, 41)); // SOMA VALOR DOS DÉBITOS DO LOTE
                    File = File.WriteInLine(42, 59, Header.ClienteSacado.ValorMoedaTotal.FormatValuesInReal(13,5).AddZeroLeftLine(42, 59)); // SOMATÓRIA DA QTDE DE MOEDAS DO LOTE
                    File = File.RightEmptyLine(60, 230); // COMPLEMENTO DE REGISTRO | BRANCO
                    File = File.RightEmptyLine(231, 240); // CÓDIGOS OCORRÊNCIAS P/ RETORNO | BRANCO

                    Result = File;

                } catch {
                    throw;
                }

                return Result;
            }

            public String WriteTrailerFile(RemessaCNAB240 Header) {
                String Result;
                String EmpresaNome = Header.EmpresaCedente.Nome;

                if (EmpresaNome.Length > 30) {
                    EmpresaNome = EmpresaNome.Substring(0, 30);
                }

                var File = new String(' ', 240);

                try {

                    File = File.WriteInLine(1, 3, "341"); // CÓDIGO BANCO NA COMPENSAÇÃO
                    File = File.WriteInLine(4, 7, "9999"); // LOTE IDENTIFICAÇÃO DE SERVIÇO 
                    File = File.WriteInLine(8, 8, "9"); // REGISTRO TRAILER DE ARQUIVO 
                    File = File.LeftEmptyLine(9, 17); //COMPLEMENTO DE REGISTRO - BRANCOS
                    File = File.WriteInLine(18, 23, Header.Registros.TotalQtdLotes.AddZeroLeftLine(18,23)); // QTDE LOTES DO ARQUIVO
                    File = File.WriteInLine(24, 29, Header.Registros.TotalQtdRegs.AddZeroLeftLine(24,29)); // QTDE REGISTROS DO ARQUIVO
                    File = File.LeftEmptyLine(30, 240); // COMPLEMENTO DE REGISTRO

                    Result = File;

                } catch {
                    throw;
                }

                return Result;
            }

        }
    }
}

public static class Write {

    public static String WriteInLine(this String Content, Int32 FromLine, Int32 ToLine, Object Value) {
        Int32 Start = FromLine - 1;
        String StringValue = Convert.ToString(Value);
        var SizeOfLine = ToLine - Start;

        if (StringValue.Length != SizeOfLine) {
            StringValue = StringValue.Substring(0, SizeOfLine);
            if (StringValue.Length != SizeOfLine) {
                throw new Exception("Shipping: Valor a Preencher: " + Value +
                                    " é diferente do tamanho do preenchimento informado. Posição inicial: " + FromLine +
                                    " até " + ToLine);
            }
        }

        // 1º remove
        Content = Content.Remove(Start, ToLine - FromLine);
        // 2º insere
        Content = Content.Insert(Start, StringValue);

        return Content;
    }

    public static String RightEmptyLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        String Content = Convert.ToString(ContentEdit);

        // 1º remove
        Content = Content.Remove(Start, ToLine - FromLine);
        // 2º insere
        Content = Content.Insert(Start, string.Empty.PadRight(SizeOfLine, ' '));

        return Content;
    }

    public static String LeftEmptyLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        String Content = Convert.ToString(ContentEdit);

        // 1º remove
        Content = Content.Remove(Start, ToLine - FromLine);
        // 2º insere
        Content = Content.Insert(Start, string.Empty.PadLeft(SizeOfLine, ' '));

        return Content;
    }

    public static String AddZeroLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
        String Content = Convert.ToString(ContentEdit);
        FromLine = FromLine + Content.Length;
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        Content += SizeOfLine < 0 ? String.Empty : new string('0', SizeOfLine);

        return Content;
    }

    public static String AddZeroRightLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine, Boolean File = true) {
        String Content = Convert.ToString(ContentEdit);
        if (File) {
            Int32 Start = FromLine - 1;
            var SizeOfLine = ToLine - Start;
            // 1º remove
            Content = Content.Remove(Start, ToLine - FromLine);
            // 2º insere
            Content = Content.Insert(Start, string.Empty.PadRight(SizeOfLine, '0'));
        } else {
            FromLine = FromLine + Content.Length;
            Int32 Start = FromLine - 1;
            var SizeOfLine = ToLine - Start;
            Content = Content + new string('0', SizeOfLine);
        }

        return Content;
    }

    public static String AddZeroLeftLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
        String Content = Convert.ToString(ContentEdit);
        FromLine = FromLine + Content.Length;
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        Content = SizeOfLine < 0 ? Content : new string('0', SizeOfLine) + Content;

        return Content;
    }

    public static String AddEmptyLine(this Object ContentEdit, Int32 FromLine, Int32 ToLine) {
        String Content = Convert.ToString(ContentEdit);
        FromLine = FromLine + Content.Length;
        Int32 Start = FromLine - 1;
        var SizeOfLine = ToLine - Start;
        Content += SizeOfLine < 0 ? String.Empty : new string(' ', SizeOfLine);

        return Content;
    }

    public static String FormatValuesInReal(this Single ContentEdit, Int32 casasAntesVirgula, Int32 casasPosVirgula) {
        String Valor = Convert.ToString(ContentEdit);
        String[] ValorPart = Valor.Split(',');

        String ValorAntesVirgula = new String(' ', casasAntesVirgula);
        String ValorAposVirgula = new String(' ', casasPosVirgula);

        ValorAntesVirgula = ValorAntesVirgula.WriteInLine(1, casasAntesVirgula, ValorPart[0].AddZeroLeftLine(1, casasAntesVirgula));

        if (ValorPart.Length > 1) {
            ValorAposVirgula = ValorAposVirgula.WriteInLine(1, casasPosVirgula, ValorPart[1].AddZeroRightLine(1, casasPosVirgula, false));
        } else {
            ValorAposVirgula = ValorAposVirgula.AddZeroRightLine(1, casasPosVirgula);
        }

        String ValorEmRealFormatado = ValorAntesVirgula.Trim() + ValorAposVirgula.Trim();
        return ValorEmRealFormatado;
    }
}