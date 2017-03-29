using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spider.APP.database;

namespace spider.APP.retrieval
{/**
  * 
  * 检索数据，防止重复
  * 
  * */
  public   class retrievals
    {
      public SortedDictionary<string, string> mdata;
      public retrievals() {

          this.mdata = new SortedDictionary<string, string>();
      
      }//获取数据；
      public SortedDictionary<string, string> getsort() { return this.mdata; }

      //验证是否重复
      public static bool checkwww(string www) {

          data_domain k = new data_domain();

          double h = k.readid(www);
          if (h == 0)
          {
              return true;

          }
          else {
              return false;
          }

      
      }

    }
}
