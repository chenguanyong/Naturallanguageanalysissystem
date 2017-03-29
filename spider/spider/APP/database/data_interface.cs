using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spider.APP.database
{
    interface data_interface
    { 
        /**
         * 读
         * */
         string read(string www);
        /**
         * 写
         * */
         string write(string www);
        /**
         * 删除
         * */
         string delete(string www);
        /**
         * 更新
         * */
         string update(string www);
    }
}
