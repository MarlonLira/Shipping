using System;

namespace Dispatch.Commons.Files
{
    public static class Format
    {

        public static Single FormatToMoney(this String Value, Int32 CasaPosVirgula) {
            Single Result = 0;
            String FormattedValue;

            FormattedValue = Value.Substring(0, Value.Length - CasaPosVirgula) + "," + 
                Value.Substring(Value.Length - CasaPosVirgula, CasaPosVirgula);

            Result = Convert.ToSingle(FormattedValue);

            return Result;
        }

        public static String FormatDate (this String Value) {
            String Result;

            Result = Value.Substring(0, 2) + "/" + Value.Substring(2, 2) + "/" + Value.Substring(4, 4);


            return Result;
        }

        public static String FormatHour(this String Value) {
            String Result;

            Result = Value.Substring(0, 2) + ":" + Value.Substring(2, 2) + ":" + Value.Substring(4, 2);


            return Result;
        }

    }
}
