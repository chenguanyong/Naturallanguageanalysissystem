using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spider.APP.database;
using spider.APP.finds;
using spider.APP.regular;
using spider.APP.retrieval;
using System.Threading;


namespace spider.APP.run
{
    /**
     * 获取相应的关键信息
     * 
     * **/
    class KeyInfor
    {
        private find mfind;
        private keyword_site_regx mreg;//find规则
        private retrievals mretri;//防止重复
        private static bool stopflog = true;//停止标志
        private SortedDictionary<string, string> wwwSort;// = new SortedDictionary<string, string>();
        private Thread mm;
        public KeyInfor() {
            this.mfind = new find();
            this.mreg = new keyword_site_regx();
            this.mretri = new retrievals();
            this.wwwSort = new SortedDictionary<string,string>();
            this.mm = new Thread(run);

        }
        public void start() {

            try {
                this.mm.Start();
            }catch(Exception g){
            
            }

        
        }
        public void run() { }
    }
}
