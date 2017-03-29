using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace participle.kernel.Txt
{
    class Punctuation
    {
        public const string pun = "。，、；：？！…—·ˉ¨‘’“”∶（）｛｝";

        public Punctuation() { 
        
        
        
        }

        //检测是否是字符串
        private bool is_punti(string str){

            if (pun.IndexOf(str) == -1) {
                return false;
            }
            return true;
        }

        //根据标点符号的用途返回相应的功能标记
        public int getpunapp(string str) {

            if (!is_punti(str)) {

                return 1;//表示继续
            }
            int d = 0;
            switch(str){
                    /***
                     * 0:表示中文
                     * 1:表示继续
                     * 2：结束
                     * 3：表示跳过并终止
                     * 4：跳过并继续
                     * ***/
                case "，": { d = 1; } break;
                case ",": { d = 1; } break;
                case "？": { d = 2; } break;
                case "?": { d = 2; } break;
                case "。": { d = 2; } break;
                case ".": { d = 2; } break;
                case "\"": { d = 4; } break;
                case "；": { d = 2; } break;
                case ";": { d = 2; } break;
                case ":": { d = 4; } break;
                case "：": { d = 4; } break;
                case "！": { d = 2; } break;
                case "!": { d = 2; } break;
                case "…": { d = 2; } break;
                case "｜": { d = 4; } break;
                case "∶": { d = 4; } break;
                case "〃": { d = 4; } break;
                case "、": { d = 4; } break;
                case "\\": { d = 4; } break;
                case "/": { d = 4; } break;

            
            }
            return d;
        }
    }
}
