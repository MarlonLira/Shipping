using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Commons {
    public class Ocorrencias {

        public String ReturnOccurrence(String Ocorrencias) {

            var Texto = new String(' ', 10);
            Texto = Ocorrencias + Texto;

            Ocorrencias = Texto.Substring(0, 10);
            String[] Teste = new String[5];

            Teste[0] = Ocorrencias.Substring(0, 2);
            Teste[1] = Ocorrencias.Substring(2, 2);
            Teste[2] = Ocorrencias.Substring(4, 2);
            Teste[3] = Ocorrencias.Substring(6, 2);
            Teste[4] = Ocorrencias.Substring(8, 2);

            String Occurrence = "";

            foreach (String Ocorrencia in Teste) {
                if (!String.IsNullOrEmpty(Ocorrencia)) {
                    switch (Ocorrencia) {
                        case "00":
                            Occurrence += "DÉBITO EFETUADO|";
                            break;

                        case "01":
                            Occurrence += "INSUFICIÊNCIA DE FUNDOS - DÉBITO NÃO EFETUADO|";
                            break;

                        case "02":
                            Occurrence += "DÉBITO CANCELADO|";
                            break;

                        case "03":
                            Occurrence += "DÉBITO AUTORIZADO PELA AGÊNCIA - EFETUADO|";
                            break;

                        case "HA":
                            Occurrence += "LOTE NÃO ACEITO|";
                            break;

                        case "HB":
                            Occurrence += "INSCRIÇÃO DA EMPRESA INVÁLIDA PARA O CONTRATO|";
                            break;

                        case "HC":
                            Occurrence += "CONVÊNIO COM A EMPRESA INEXISTENTE/INVÁLIDO PARA O CONTRATO|";
                            break;

                        case "AA":
                            Occurrence += "CONTROLE INVÁLIDO|";
                            break;

                        case "AB":
                            Occurrence += "TIPO DE OPERAÇÃO INVÁLIDO|";
                            break;

                        case "AC":
                            Occurrence += "TIPO DE SERVIÇO INVÁLIDO|";
                            break;

                        case "AD":
                            Occurrence += "FORMA DE LANÇAMENTO INVÁLIDA|";
                            break;

                        case "AF":
                            Occurrence += "CÓDIGO DE CONVÊNIO INVÁLIDO|";
                            break;

                        case "AH":
                            Occurrence += "NR. SEQUENCIAL DO REGISTRO NO LOTE INVÁLIDO|";
                            break;

                        case "AI":
                            Occurrence += "CÓDIGO DE SEGMENTO DE DETALHE INVÁLIDO|";
                            break;

                        case "AJ":
                            Occurrence += "TIPO DE MOVIMENTO INVÁLIDO|";
                            break;

                        case "AL":
                            Occurrence += "CÓDIGO DO BANCO INVÁLIDO|";
                            break;

                        case "AM":
                            Occurrence += "AGÊNCIA MANTEDORA DA CONTA CORRENTE DO DEBITADO INVÁLIDA|";
                            break;

                        case "AN":
                            Occurrence += "CONTA CORRENTE/DÍGITO VERIFICADORA DO DEBITADO INVÁLIDO|";
                            break;

                        case "AP":
                            Occurrence += "DATA LANÇAMENTO INVÁLIDA|";
                            break;

                        case "AQ":
                            Occurrence += "TIPO/QUANTIDADE DA MOEDA INVÁLIDA|";
                            break;

                        case "AR":
                            Occurrence += "VALOR DO LANÇAMENTO INVÁLIDO|";
                            break;

                        case "AS":
                            Occurrence += "PARCELA VINCULADA|";
                            break;

                        case "IA":
                            Occurrence += "TIPO DO ENCARGO INVÁLIDO|";
                            break;

                        case "IB":
                            Occurrence += "C/C COM RESTRIÇÃO|";
                            break;

                        case "IC":
                            Occurrence += "C/C DO DEBITADO EM LIQUIDAÇÃO|";
                            break;

                        case "ID":
                            Occurrence += "VALOR DA MORA / TAXA DA MORA INVÁLIDA|";
                            break;

                        case "IE":
                            Occurrence += "CONTA CORRENTE DO DEBITADO ENCERRADA|";
                            break;

                        case "IF":
                            Occurrence += "TAXA DA MORA MAIOR QUE 50,00000 %|";
                            break;

                        case "IG":
                            Occurrence += "COMPLEMENTO DE HISTÓRICO INVÁLIDO|";
                            break;

                        case "IH":
                            Occurrence += "CONTA CORRENTE PARA CRÉDITO NÃO AUTORIZADA|";
                            break;

                        case "II":
                            Occurrence += "CANCELAMENTO NÃO ENCONTRADO|";
                            break;

                        case "IK":
                            Occurrence += "VALOR DO DÉBITO ACIMA DO LIMITE|";
                            break;

                        case "IL":
                            Occurrence += "LIMITE DIÁRIO DE DÉBITO ULTRAPASSADO|";
                            break;

                        case "IM":
                            Occurrence += "CPF/CNPJ DO DEBITADO INVÁLIDO|";
                            break;

                        case "IN":
                            Occurrence += "CPF/CNPJ DO DEBITADO NÃO PERTENCE À CONTA CORRENTE INDICADA|";
                            break;

                        case "IZ":
                            Occurrence += "RESERVADO ( DATA DA MORA)|";
                            break;

                        case "TA":
                            Occurrence += "LOTE NÃO ACEITO - TOTAIS DO LOTE COM DIFERENÇA|";
                            break;

                        case "PE":
                            Occurrence += "DÉBITO PENDENTE DE AUTORIZAÇÃO|";
                            break;

                        case "NA":
                            Occurrence += "DÉBITO NÃO AUTORIZADO|";
                            break;

                        case "AT":
                            Occurrence += "DEBITO AUTORIZADO|";
                            break;

                        case "RC":
                            Occurrence += "DÉBITO RECUSADO|";
                            break;
                    }
                }
            }

            return Occurrence;
        }

    
    }
}
