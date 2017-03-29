using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spider.APP.database;
using spider.APP.finds;
using spider.APP.regular;
using spider.APP.retrieval;
using System.Threading;
using spider.lib.function;
using System.Net;

namespace spider.APP.run
{
    class find_site
    {
        private find mfind;
        private regulars mreg;//find规则
        private retrievals mretri;//防止重复
        private  static  bool stopflog=true;//停止标志
        private SortedDictionary<string, string> wwwSort;// = new SortedDictionary<string, string>();
        private Thread mthread;
        public find_site() {
            mthread = new Thread(run);
            this.mfind = new find();
            this.mreg = new regulars();
            this.mretri = new retrievals();
            this.wwwSort = new SortedDictionary<string, string>();
        }

        public void start() {

            this.mthread.Start();
        
        }
        /*
        public void run() {

            bool folg=true;
            string tempw="http://www.qq.com/";
           // string www = this.mdata.readone();
             string url1 = "";
            string data = "";
            SortedDictionary<string, string> mm = new SortedDictionary<string, string>();
            while(stopflog){

                data_domain mdata = new data_domain();
                mdata.chagedatabase("linbei_spider");
                url1 = html_string.is_domain(tempw);


                int o=0;
                foreach (KeyValuePair<string, string> k in mm) {

                    Console.Write("正在保存数据{0}>>{1}\n",k.Key,url1);
                    bool f=false;
                   f =  mdata.insert(k.Key,o);

                   if (!f) {
                       Console.Write("存储失败");
                   
                   }
                    o++;

                    if (folg)
                    {
                         string temp_www = html_string.is_domain(k.Key);
                       if(url1 != temp_www){ 
                        
                            tempw = k.Key;
                            folg = false;
                        }

                    }
                
                }


                if (folg)
                {

                    tempw = mdata.last();
                    
                    if (tempw == null) {
                        tempw = "http://www.hao123.com/";
                    }
                    tempw = tempw.Trim();
                }
                else {

                    folg = true;
                }
                data = mfind.read_utf8(tempw);
                if (data == null) {

                    continue;
                }
                mdata.close();
                mm.Clear();
            mm = mreg.getWWW(tempw, data, this.mreg.text_4mu);
            }


        
        
        
        }*/
        public void run()
        {

            string[] mu = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string[] domains = new string[]{

"com","cn","com.cn","net","gov.cn","gov","edu.cn","mil","cc","org","win","bid","pro"};
            data_domain mdata = new data_domain();
            mdata.chagedatabase("linbei_spider");

            int[] mint = new int[8] { 0, -1, -1, -1, -1, -1, -1, -1 };
            string url = "";
            while (true)
            {
                if (mint[7] >= 35)
                {
                    break;

                }

                for (int i = 0; i < 7; i++)
                {

                    if (mint[i] > 35)
                    {
                        if (mint[i + 1] == -1)
                        {
                            mint[i + 1] = 0;

                        }
                        mint[i + 1]++;
                        mint[i] = 0;
                    }

                }
                Console.Write("" + mint[0] + mint[1] + mint[2] + mint[3] + mint[4] + mint[5] + mint[6] + mint[7] + "\n");
                for (int a = 0; a < 7; a++)
                {

                    if (mint[a] == -1) { break; }
                    url = url + mu[mint[a]];


                }
                //int state = 1;
                for (int b = 0; b < 13; b++)
                {


                    string urls = "www." + url + "." + domains[b];
                  bool  f = mdata.insert(urls, b);

                    if (!f)
                    {
                        Console.Write("存储失败");

                    }
/*
                    Console.Write(urls + "\n");
                    IPHostEntry hostInfo = null;
                    try
                    {
                        hostInfo = Dns.GetHostByName(urls);


                    }
                    catch (Exception e)
                    {

                        state = 0;
                    }
                    if (hostInfo != null)
                    {
                        string ip = hostInfo.AddressList.ElementAt(0).ToString();
                        Console.Write(ip + "\n");
                    }
                    else
                    {

                        state = 0;
                        Console.Write("不存在" + "\n");
                    }*/

                }








                url = "";
                mint[0]++;





            }

            mdata.close();
        }
        public static  void setStopfig(bool stopflog1) {

            stopflog = stopflog1; 
        
        
        }

        public static bool getStopfig() {

            return stopflog;
        }
    }
}
