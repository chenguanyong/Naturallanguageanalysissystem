using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spider.lib.mysql;
namespace spider.APP.database
{/**
  * 处理检索到的数据
  * 
  * */
  public  class Data_result
    {
        private mysql mmysql;
        private long lastid = 0;
        public Data_result()
              {
            mmysql = new mysql();
            mmysql.chagedatabase("linbei_spider");

        }
      //改变数据库
        public void chagedatabase(string databse) {

            this.mmysql.chagedatabase(databse);
        
        }
      //插入数据
        public bool insert(string sql) {

            bool f = this.mmysql.mysql_write(sql);

            if (f)
            {
                return false;
            }
            else {
                return true;
            }

            
        }

        public long getlastid() {

            return this.lastid;
        }
      




    }
}
