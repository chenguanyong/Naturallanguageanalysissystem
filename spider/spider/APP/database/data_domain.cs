using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spider.lib.mysql;

namespace spider.APP.database
{
    class data_domain
    {
        
        private mysql mmysql;
        private long lastid;
        public data_domain() {
            mmysql = new mysql();
            mmysql.chagedatabase("linbei_spider");
            this.lastid = 0;
        }
        public void chagedatabase(string databse) {

            this.mmysql.chagedatabase(databse);
        
        }
        /**
         *  检查是否重复域名
         * 
         * */
        public bool check(string url) {
            bool re = false;
            try
            {
               re  = this.mmysql.mysql_write("INSERT INTO [linbei_spider].[dbo].[domain] ([www]) VALUES ('" + url + "')");
            }catch(Exception gf){
                return false;
            
            }

            return re? true:false;
        }
        /**
         * 插入域名
         * 
         * */
        public bool insert(string url,int j) {

            int random = j;
           
            DateTime date = DateTime.Now;//.ToString();
            string w_id = date.Year.ToString() + date.Month + date.Day + date.Hour + date.Minute + date.Millisecond+random;
            bool re;
            try
            {
                re = this.mmysql.mysql_write("INSERT INTO [linbei_spider].[dbo].[domain] ([www],w_id) VALUES ('" + url + "','"+w_id+"')");
            }
            catch (Exception gf)
            {
                return false;

            }

            return re ? true : false;
        
        }
        //查一条网址
        public string readone() {

            string result = this.mmysql.mysql_readone("select www from domain where state=0");
            return result;
        }
        //查询ID 
        public double readid(string www) {

            string id = this.mmysql.mysql_readone("select id from domain where www='"+www+"'");
            double id_ = Double.Parse(id);
            return id_ == 0 ? id_ : 0;


        }

        public SortedDictionary<long, string> select(string sql) {

            SortedDictionary<long, string> msort = this.mmysql.mysql_read_long(sql);

            if (msort.Count == 0)
            {

                return null;
            }
            else {
                this.lastid = this.mmysql.getlastid();
                return msort;
            
            }

           
        }
        /*
         *随机查一条数据 
         */
        public string last() {
            string count = this.mmysql.mysql_readone("select max(id) from domain");
            string count1 = this.mmysql.mysql_readone("select min(id) from domain");
            if (count == null) {

                return null;
            }
            if (count1 == null)
            {

                return null;
            }

            Random m = new Random();
            long mk = long.Parse(count) - long.Parse(count1);
           long d= m.Next(0,(int)mk)+long.Parse(count1);
            string www = this.mmysql.mysql_readone("select www from domain where id = "+d);

            return www;
        }
        //关闭数据库
        public void close() {

            this.mmysql.mysql_close();
        
        }

        public long getlastid()
        {

            return this.lastid;
        }
    }
}
