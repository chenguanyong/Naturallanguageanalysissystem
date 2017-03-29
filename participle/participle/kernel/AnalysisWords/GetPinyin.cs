using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.International.Converters.PinYinConverter;
namespace participle.kernel.AnalysisWords
{
   public  class GetPinyin
    {

        public static string getSimplePinYin(string inputTxt)
        {

            string shortR = "";
            foreach (char c in inputTxt.Trim())
            {
                Console.Write(c);
                ChineseChar chineseChar = new ChineseChar(c);
                shortR += chineseChar.Pinyins[0].Substring(0, 1).ToLower();
            }
            return shortR;
        }
        public static  string getAllPinYin(string inputTxt)
        {
            string allR = "";
            foreach (char c in inputTxt.Trim())
            {
                ChineseChar chineseChar = new ChineseChar(c);
                allR += chineseChar.Pinyins[0].Substring(0, chineseChar.Pinyins[0].Length - 1).ToLower();
            }
            return allR;
        }

    }
}
