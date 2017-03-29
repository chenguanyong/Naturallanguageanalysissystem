using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spider.lib.mysql;
using System.Text.RegularExpressions;

namespace spider.APP.regular
{
    class RegularNew
    {
        private string sql = "INSERT INTO [linbei].[dbo].[article]([unmbers],[title],[author],[comment],[link],[source],[famil],[brows],[createtime],[state])";
        private const string newtitle = @"<h[0-9][\s\S]*?>(?<title>[\s\S]*?)</h[0-9]>|<p>(?<content>[\s\S]*?)</p>";
        private mysql mmysql;//数据库句柄
        private string db_name = "linbei";//数据库名称
        public RegularNew() {
            this.mmysql = new mysql();

            this.mmysql.chagedatabase(this.db_name);
        }

        //新闻
        public bool get_information_bd(string html, string link)
        {

            DateTime date = DateTime.Now;
            string w_id = date.Year.ToString() + date.Month + date.Day + date.Hour + date.Minute + date.Millisecond;
            MatchCollection mk = Regex.Matches(html, newtitle, RegexOptions.IgnoreCase);

            int i = 0;
            string title = "";
            string content = "";
            foreach (Match f in mk)
            {
                GroupCollection kl = f.Groups;

                title  = title + kl["title"].Value;
                content  = content + kl["content"].Value;


            }
            try
            {
                this.mmysql.mysql_write("INSERT INTO [linbei].[dbo].[article]([unmbers],[title],[author],[comment],[source],[createtime]) VALUES('" + "wenzhangbiaohao" + ",'" + title + "','" + "sys" + "','" + content + "','" + link + "','" + date + "')");
            }
            catch (Exception g)
            {
                return false;
               
            }

            return true;
        }
    }
}
