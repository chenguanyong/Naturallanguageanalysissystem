using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace spider.APP.finds
{
    class find :net_interface
    {
        private WebClient mwebclict;//web浏览器
        private SortedDictionary<string, string> m;
        public find() {
            mwebclict = new WebClient();
            m = new SortedDictionary<string, string>();
        
        }
        public SortedDictionary<string, string> getsort() {

            return this.m;
        
        }
        //
        public string read(string url) {

            byte[] data=this.mwebclict.DownloadData(url);
            if (data.Length == 0)
            {
                return null;
            }
            return ASCIIEncoding.ASCII.GetString(data);
        }
        //读取ut8数据
        public string read_utf8(string url)
        {
            byte[] data = null;
        try
        {
            data = this.mwebclict.DownloadData(url);

        }catch(Exception e){

            return null;
        }
            
            if (data.Length == 0)
        {
                return null;
            }

            
            return ASCIIEncoding.UTF8.GetString(data);
        }
    }
}
