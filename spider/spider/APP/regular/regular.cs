using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using spider.lib.mysql;

namespace spider.APP.regular
{/**
  * 
  * 正则表达式
  * */
  public    class regulars
    {
        //string text = @"href=" + "\"" + @"http://[A-Z,a-z,-,0-9]+\.[A-Z,a-z,-,0-9]+\.[A-Z,a-z,-,0-9]+" + "\"";
    public        string text_ban = @"http://([A-Z,a-z,-,0-9]+\.)+[A-Z,a-z,-,0-9]*\/";//获取域名
    public       string text_all = @"http://([A-Z,a-z,-,0-9]+\.)+[A-Z,a-z,-,0-9]*\/[A-Z,a-z,-,0-9,\/,?,=]*";//获取详细链接
    public       string text_4mu= @"http://[A-Z,a-z,-,0-9]+\.[A-Z,a-z,-,0-9]+\.[A-Z,a-z,-,0-9]+\.[A-Z,a-z,-,0-9]*\/";//2目子域名
    private string keyword_reg_text = @"<meta\s?name=\Wkeyword\W\s?content=.?>";
    private string descript_reg_text = @"<meta\s?name=\Wdescription\W\s?content=.?>";
    private string h_txt = @"<h[0-9].?>.?</h[0-9]>";
    private string bordy_txt = @"<p.*>.?</p>";//获取文章内容
    private string imag_txt = @"<p.*><img.*href=.?.*>";//获取文章中的配图；

      public regulars() { 
      
      }
      public SortedDictionary<string, string> getWWW(string url, String j, string type) {

          SortedDictionary<string, string> mm = new SortedDictionary<string, string>();
         // string text = @"<meta[ ]{1}name=""keywords""[ ]{1}content=.*" + @"""";
          // string text = @"content=\""/>";
          MatchCollection mk = Regex.Matches(j, type, RegexOptions.IgnoreCase);
          int i = 0;
          string fd = "";
          foreach (Match f in mk)
          {
              fd = f.Value;
              Console.Write("sdsdsd" + f.Value + "\n");
              try
              {
                  if (fd.IndexOf(url) == -1)
                  {
                      mm.Add(f.Value, "d" + i);
                  }
                   i++;
              }
              catch (Exception g)
              {

                  continue;
              }
              //i++;
          }
          return mm;
      }
      /**
       * 获取网站的keyword，和description
       * @return array
       * @string text
       **/
      public string[] getJianjie(string text){
          string []d= new string[3];
          MatchCollection mk = Regex.Matches(text,keyword_reg_text, RegexOptions.IgnoreCase);
          
          foreach (Match f in mk)
          {
              d[0] = f.Value;
          
          }
          MatchCollection mk1= Regex.Matches(text,descript_reg_text,RegexOptions.IgnoreCase);

          foreach (Match f in mk)
          {
              d[1] = f.Value;
          }
          return d ;
      }
      /**
       *获取文章
       * */
      public SortedDictionary<string, string> getTxt(string txt){
          SortedDictionary<string, string> mm = new SortedDictionary<string, string>();
          MatchCollection mk1 = Regex.Matches(txt, h_txt, RegexOptions.IgnoreCase);
          int i = 0;
          foreach (Match f in mk1)
          {
              //d[1] = f.Value;
              mm.Add("title" + i, f.Value);
              i++;
          }
          mk1 = Regex.Matches(txt,bordy_txt,RegexOptions.IgnoreCase);
          foreach (Match f in mk1)
          {
              //d[1] = f.Value;
              mm.Add("p" + i, f.Value);
              i++;
          }
          mk1 = Regex.Matches(txt, imag_txt, RegexOptions.IgnoreCase);
          foreach (Match f in mk1)
          {
              //d[1] = f.Value;
              mm.Add("img" + i, f.Value);
              i++;
          }

          return mm;
      }
      /**
       * 下载图片
       * 
       * */
      public string getImage(string url) {



          return "";
      }
      /**
       *下载视屏 
       */
      public string getTv() {


          return "";
      }


    }
  public class site_tool {

      public string chinaz_www = "http://icp.chinaz.com/?s="; //查询域名
      public string chinaz_wa = "http://icp.chinaz.com/psorgan?t=2&host=hao123.com&vcode=";//查询网安备案
      public string chinaz_whois = "http://whois.chinaz.com/";//查询whois
      public string chinaz_bdqz = "http://rank.chinaz.com/?host=www.hao123.com";//百度权重
      public string chinaz_360qz = "http://rank.chinaz.com/sorank?host=www.hao123.com";//360权重
      public string chinaz_alexa = "http://alexa.chinaz.com/?domain=www.onegreen.net";//alexa排序
      public string chinaz_seo = "http://seo.chinaz.com/?q=www.onegreen.net";//seo排序
      
      public site_tool() { 
      
      
      
      }
      //查询域名
      public SortedDictionary<string, string> getchinaz_www(string www) {



          return null;
      }
      //查询网安备案
      public SortedDictionary<string, string> getchinaz_wa(string www) {

          return null;
      }
      //查询whois
      public SortedDictionary<string, string> getchinaz_whois(string ww) { return null; }
      //Alexa排序
      public SortedDictionary<string, string> getchinaz_alexa(string ww) { return null; }
      //seo排序
      public SortedDictionary<string, string> getchinaz_seo(string seo) { return null; }
      //360排序
      public SortedDictionary<string, string> getchinaz_360(string www) { return null; }
      //百度权重
      public SortedDictionary<string, string> getchinaz_baidu(string www) { return null; }
  }


  public class keyword_site_regx {


      private const string baidu = @"<h3 class=""t""\s*>[.\s\S]*?href\s*=""(?<href>.*?)""[.\s\S]*?</a>";//百度网页
      private const string baidunews = @"<h3 class=""c-title"">\s*<a[\s\S]*?href\s*=\s*""(?<href>.*?)""[\s\S]*? >(?<word>.*?)</a></h3>[\s\S]*?<p class=""c-author"">(?<time>.*?)</p>";//百度新闻
      private const string baiduweku = @"<p class=""fl"">[\s\S]*?<a[\s\S]*?href\s*=\s*""(?<href>.*?)""[\s\S]*?>(?<word>.*?)</a>[.\s\S]*?<div class=""detail lh21"">\n+(?<time>[\s\S]*?)<i>";//百度文库
      private const string baidutiba = @"<div class=""s_post"".*?<span class=""p_title""><a[\s\S]*?href\s*=\s*""(?<href>.*?)""[\s\S]*?>(?<word>.*?)</a>.*?<font[\s\S]*?class=""p_green p_date"">(?<time>.*?)</font>?";//百度贴吧
      private const string baiduzhidao = @"<dt class=""dt mb-4 line""[\s\S]*?>[\s\S]*?<a[\s\S]*?href\s*=\s*""(?<href>.*?)""[\s\S]*?>(?<word>.*?)</a>[.\s\S]*?<dd class=""dd explain f-light""[.\s\S]*?>[.\s\S]*?<span class=""mr-8"">(?<time>[.\s\S]*?)</span>";
      private mysql mmmysql;
      private string dbname = "linbei_spider";
      public keyword_site_regx() { 
        mmmysql = new mysql();

        mmmysql.chagedatabase(this.dbname);
      
      }

      //处理百度HTML
      public bool get_information_baidu(string html) {

          DateTime date = DateTime.Now;
          string w_id = date.Year.ToString() + date.Month + date.Day + date.Hour + date.Minute + date.Millisecond ;
          MatchCollection mk = Regex.Matches(html, baidu, RegexOptions.IgnoreCase);

          string word = "";
          int i = 0;
          foreach (Match f in mk)
          {
              GroupCollection kl = f.Groups;

              string href = kl["href"].Value;

              word = spider.lib.function.html_string.strip_tags(f.Value);
              string w = w_id + i;
              try
              {
                  this.mmmysql.mysql_write("INSERT INTO [linbei_spider].[dbo].[result]([inform_id],[title],[href],[time],[createtime],[updatetime]) VALUES("+w+",'"+word+"','"+href+"','"+date+"','"+date+"','"+date+"')");
              }
              catch (Exception g)
              {

                  continue;
              }
              i++;
          }

          return false;
      }
      //处理百度文库
      public bool get_information_bd(string html)
      {

          DateTime date = DateTime.Now;
          string w_id = date.Year.ToString() + date.Month + date.Day + date.Hour + date.Minute + date.Millisecond;
          MatchCollection mk = Regex.Matches(html, baiduweku, RegexOptions.IgnoreCase);
          
          int i = 0;
          foreach (Match f in mk)
          {
              GroupCollection kl = f.Groups;

              string href = kl["href"].Value;
              string word = kl["word"].Value;
              string time = kl["time"].Value;
              word = spider.lib.function.html_string.strip_tags(word);
              string w = w_id + i;
              try
              {
                  this.mmmysql.mysql_write("INSERT INTO [linbei_spider].[dbo].[result]([inform_id],[title],[href],[time],[createtime],[updatetime]) VALUES(" + w + ",'" + word + "','" + href + "','" + time + "','" + date + "','" + date + "')");
              }
              catch (Exception g)
              {

                  continue;
              }
              i++;
          }

          return false;
      }
      //百度贴吧
      public bool get_information_bd_tb(string html)
      {

          DateTime date = DateTime.Now;
          string w_id = date.Year.ToString() + date.Month + date.Day + date.Hour + date.Minute + date.Millisecond;
          MatchCollection mk = Regex.Matches(html, baidutiba, RegexOptions.IgnoreCase);

          int i = 0;
          foreach (Match f in mk)
          {
              GroupCollection kl = f.Groups;

              string href = kl["href"].Value;
              string word = kl["word"].Value;
              string time = kl["time"].Value;
              word = spider.lib.function.html_string.strip_tags(word);
              string w = w_id + i;
              try
              {
                  this.mmmysql.mysql_write("INSERT INTO [linbei_spider].[dbo].[result]([inform_id],[title],[href],[time],[createtime],[updatetime]) VALUES(" + w + ",'" + word + "','" + href + "','" + time + "','" + date + "','" + date + "')");
              }
              catch (Exception g)
              {

                  continue;
              }
              i++;
          }

          return false;
      }
      //百度新闻
      public bool get_information_bd_news(string html)
      {

          DateTime date = DateTime.Now;
          string w_id = date.Year.ToString() + date.Month + date.Day + date.Hour + date.Minute + date.Millisecond;
          MatchCollection mk = Regex.Matches(html, baidunews, RegexOptions.IgnoreCase);

          int i = 0;
          foreach (Match f in mk)
          {
              GroupCollection kl = f.Groups;

              string href = kl["href"].Value;
              string word = kl["word"].Value;
              string time = kl["time"].Value;
              word = spider.lib.function.html_string.strip_tags(word);
              string w = w_id + i;
              try
              {
                  this.mmmysql.mysql_write("INSERT INTO [linbei_spider].[dbo].[result]([inform_id],[title],[href],[time],[createtime],[updatetime]) VALUES(" + w + ",'" + word + "','" + href + "','" + time + "','" + date + "','" + date + "')");
              }
              catch (Exception g)
              {

                  continue;
              }
              i++;
          }

          return false;
      }
      //百度知道
      public bool get_information_bd_zd(string html)
      {

          DateTime date = DateTime.Now;
          string w_id = date.Year.ToString() + date.Month + date.Day + date.Hour + date.Minute + date.Millisecond;
          MatchCollection mk = Regex.Matches(html, baidunews, RegexOptions.IgnoreCase);

          int i = 0;
          foreach (Match f in mk)
          {
              GroupCollection kl = f.Groups;

              string href = kl["href"].Value;
              string word = kl["word"].Value;
              string time = kl["time"].Value;
              word = spider.lib.function.html_string.strip_tags(word);
              string w = w_id + i;
              try
              {
                  this.mmmysql.mysql_write("INSERT INTO [linbei_spider].[dbo].[result]([inform_id],[title],[href],[time],[createtime],[updatetime]) VALUES(" + w + ",'" + word + "','" + href + "','" + time + "','" + date + "','" + date + "')");
              }
              catch (Exception g)
              {

                  continue;
              }
              i++;
          }

          return false;
      }

  
  
  
  
  
  
  
  }
}
