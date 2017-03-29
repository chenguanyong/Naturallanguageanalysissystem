using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spider.lib.mysql;

namespace spider.APP.database
{
  public   class keyword_db
    {
        private mysql mmysql;
        protected string db_name = "linbei_spider";
        public keyword_db() {

            this.mmysql = new mysql();

            this.mmysql.chagedatabase(this.db_name);


        }
        //获取全部的关键字和关键字ID 
        public SortedDictionary<long, string> getkeyword_all() {

            SortedDictionary<long, string> msort = new SortedDictionary<long, string>();

            msort = this.mmysql.mysql_read_long("select k_id, keyword form keyword");

            if (msort == null)
            {

                return null;

            }
            else {

                return msort;

            }
        }
        //更新关键字列表
        public SortedDictionary<long, string> getkeyword_update( SortedDictionary<long,string> oldsort)
        {

            SortedDictionary<long, string> msort = new SortedDictionary<long, string>();
            DateTime mdate = DateTime.Now;
            mdate = mdate.AddMinutes(-30);
            msort = this.mmysql.mysql_read_long("select k_id, keyword form keyword where createtime>'"+mdate.ToString());

            if (msort == null)
            {

                return null;

            }
            else
            {
                foreach (KeyValuePair<long, string> mk in msort) {

                    oldsort.Add(mk.Key,mk.Value);
                
                
                }
                return msort;

            }
        }
        //关闭数据库
        public void close() {

            this.mmysql.mysql_close();
        }
    }
}
