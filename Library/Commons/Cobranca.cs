using System;

namespace Library.Commons
{
    public class Cobranca
    {
        public String Descricao { get; set; }
        public Single Valor { get; set; }
        public Single PctIOF { get; set; }
        public DateTime Data { get; set; }


        public void Verificar() {
            String Error = String.Empty;
            if (String.IsNullOrEmpty(Descricao)) {
                Error += "A descrição da cobrança não foi informada! ";
            }
            if (Valor <= 0) {
                Error += "O valor da cobrança não foi informado! ";
            }
            if (Data == default(DateTime)) {
                Error += "A data da cobrança não foi informada! ";
            }
            if (!String.IsNullOrEmpty(Error)) {
                throw new Exception(Error);
            }
        }
    }
}
