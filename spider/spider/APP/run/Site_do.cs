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
  public  class Site_do
    {
        private find mfind;
        private regulars mreg;//find规则
        private retrievals mretri;//防止重复
        private  static  bool stopflog=true;//停止标志
        private SortedDictionary<string, string> wwwSort;// = new SortedDictionary<string, string>();
        private Thread mthread;
        public Site_do()
        {
            mthread = new Thread(run);
            this.mfind = new find();
            this.mreg = new regulars();
            this.mretri = new retrievals();
            this.wwwSort = new SortedDictionary<string, string>();
        }

        public void start() {

            this.mthread.Start();
        
        }

        public void run() {
            long id = 0;
            Regular_News mreg = new Regular_News();
            while(stopflog){
                string sql = "select id,WWW from domain where id >" + id + "and id<" + (id + 10);
                data_domain mm = new data_domain();

                SortedDictionary<long, string> msortWWW = mm.select(sql);
                id = mm.getlastid();
                mm.close();
                if (msortWWW == null) { continue; }
                
                foreach(KeyValuePair<long ,string> mk in msortWWW){
                   
                    string html = this.mfind.read_utf8(mk.Value);

                    
                    if (html == null) { continue; }
                    SortedDictionary<string, string> ml = this.mreg.getWWW(mk.Value, html, this.mreg.text_all);
                    if (ml == null && ml.Count == 0) { continue; }

                    string title = mreg.gettitle();//获取网页的头

                    //保存到数据库
                    
                    foreach(KeyValuePair<string,string> mkey in ml){
                        string html1 = this.mfind.read_utf8(mkey.Value);


                        if (html == null) { continue; }
                        SortedDictionary<string, string> mll = this.mreg.getWWW(mkey.Value, html1, this.mreg.text_all);
                        foreach (KeyValuePair<string, string> kk in mll) {

                            ml.Add(kk.Key, kk.Value);
                        
                        }
                        mll = null;
                        //处理文章和网页


                        ml.Remove(mkey.Key);
                    
                    }


                }

            }
        
        
        
        
        }
      

    }
}
