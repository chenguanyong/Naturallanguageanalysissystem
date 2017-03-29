using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Util;


namespace spider.lib.function
{
    class html_string
    {
        //去除HTML标签
        public static string strip_tags(string html) {

            string pattern = @"<[.,\s,\S]*?>";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(html, replacement);

            ///Console.WriteLine("Original String: {0}", input);
            ///Console.WriteLine("Replacement String: {0}", result);
            return result;
        }

        //URL编码
        public static string urlencode(string str) {

            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());

        }
        //URL解码
        public static string urldecode(string str) {
            String sb = "";
            string msm = str.Replace("%","");
            byte[] mbyte = Encoding.UTF8.GetBytes(msm);
            for (int i = 0; i < mbyte.Length;i++ )
            {
                sb = sb + Encoding.UTF8.GetString(new byte[]{mbyte[i],mbyte[i+1]});

            }          
            return sb; 

            
        }

        //判断时间是否符合规定
        public static bool is_date(string date)
        {
            string paten = @"^[0-9]{0,4}.[0-9]{0,2}.[0-9]{0,2}.[0-9]{0,2}.[0-9]{0,2}.[0-9]{0,2}&";
            Regex m = new Regex(paten);
            return m.IsMatch(paten);
        }

        //检查domain是否合法
        public static string is_domain(string domain) {
            string[] main = domain.Split('.');

            const string domian_g = "|asia|kim|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|";
            const string domain_g1 = "|by|bz|ca|cc|cf|cg|ch|ci|ck|cl|cm|cn|co|cq|cr|cu|cv|cx|cy|cz|de|dj|dk|dm|do|dz|ec|ee|eg|eh|es|et|ev|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gh|gi|gl|gm|gn|gp|gr|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|in|io|iq|ir|is|it|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|mg|mh|ml|mm|mn|mo|mp|mq|mr|ms|mt|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nt|nu|nz|om|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|pt|pw|py|qa|re|ro|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|sk|sl|sm|sn|so|sr|st|su|sy|sz|tc|td|tf|tg|th|tj|tk|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|us|uy|va|vc|ve|vg|vn|vu|wf|ws|ye|yu|za|zm|zw|";
           const  string domian_cn_b = "|ac|ah|bj|cq|fj|gd|gs|gx|gz|ha|hb|he|hi|hk|hl|hn|jl|js|jx|ln|mo|nm|nx|qh|sc|sd|sh|sn|sx|tj|tw|xj|xz|yn|zj|";
           const  string domian_cn_c = "|gov|mil|ac|edu|net|org|com|";
           const  string domian_c = "|com|vip|top|win|red|net|org|wang|gov|edu|mil|co|biz|name|info|mobi|pro|travel|club|museum|int|aero|post|rec|asia|";

           int main_length = main.Length;
            string last = main[main_length - 1].Replace("/","");
            if(last == "cn"){
                if (domian_cn_c.IndexOf(main[main_length - 2]) != -1)
                {
                    return main[main_length - 3];
                }
                else if (domian_cn_b.IndexOf(main[main_length - 2]) != -1)
                {
                    return main[main_length - 3];

                }
                else {
                    return main[main_length - 2];
                
                }


            }
            else if (domian_c.IndexOf(last) != -1) {

                return main[main_length - 2];

            }
            else if (domian_g.IndexOf(last) != -1)
            {

                return main[main_length - 2];

            }
            else if (domain_g1.IndexOf(last) != -1)
            {

                return main[main_length - 2];

            }
            else { return null; }

        }
    }
}
