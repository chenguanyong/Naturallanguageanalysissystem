using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spider.APP.finds
{
  public   interface net_interface
    { 
        /*
         * 读取网络数据
         * @string url
         * @return string
         */
        string read(string url);
        
        
    }
}
