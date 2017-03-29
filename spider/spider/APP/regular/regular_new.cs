using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spider.lib.mysql;
namespace spider.APP.regular
{
    class Regular_News
    {
        private const string site_news = @"<h[0-9]?[\s\S]*?>(?<title>[\s\S]*?)</h[0-9]?>|<p>(?<con>[\s\S]*?)</p>";//文章内容
        public Regular_News() { 
        
        
        }
        public string gettitle() {

            return "";
        
        }


    }
}
