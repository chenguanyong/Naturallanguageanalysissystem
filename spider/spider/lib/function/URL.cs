using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spider.lib.function
{
    class URL
    {
        public URL() { 
        
        }
        //构造百度网页
        public string getbaiduurl(string keyword, int page) {

            string urlkeyword = html_string.urlencode(keyword);

             page = page * 10;

            return "http://www.baidu.com/s?ie=utf-8&wd=" + urlkeyword + "&pn=" + page; 
        }
        //构造百度文库URL
        public string getbaiduwenkuurl(string keyword, int page) {

            string urlkeyword = html_string.urlencode(keyword);

            page = page * 10;
            
            return "http://wenku.baidu.com/search?ie=utf-8&word=" + keyword + "&pn=" + page;
        }
        //构造百度新闻URL
        public string getbaidunewurl(string keyword, int page) {
            string urlkeyword = html_string.urlencode(keyword);

            page = page * 20;
            
            
            return "http://news.baidu.com/ns?word="+keyword+"&pn="+page+"&tn=news&rn=20&ie=utf-8";
        }
        //构造百度贴吧URL
        public string getbaidutieba(string keyword, int page) { 
           string urlkeyword = html_string.urlencode(keyword);

            page = page * 10;
            
            return "http://tieba.baidu.com/f/search/res?&qw=" + keyword +"&pn=" + page;
        }
        //构造百度知道URL
        public string getbaiduzhidao(string keyword, int page)
        {
            string urlkeyword = html_string.urlencode(keyword);

            page = page * 10;

            return "https://zhidao.baidu.com/search?word="+keyword+"&ct=17&pn="+page+"&tn=ikaslist&rn=10&lm=0&fr=wenku";
        }
    }
}
