using System;

namespace Dispatch.Commons.Shipping {
    public class ReadReturn {


        public static String[] ReturnTxtPart(String Path) {
            //C:\Users\suporte\Desktop\Repo\RET341-Itaú_011020193705_HEADER.txt
            string[] lines = System.IO.File.ReadAllLines(Path);

            return lines;

        }

        public static String ReturnTxt(String Path) {
            //C:\Users\suporte\Desktop\Repo\RET341-Itaú_011020193705_HEADER.txt
            string lines = System.IO.File.ReadAllText(Path);

            return lines;

        }
    }
}
