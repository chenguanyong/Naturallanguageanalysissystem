using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using participle.lib.data;
using System.Threading;
using Microsoft.International.Converters.PinYinConverter;
using participle.lib.xml;
using participle.lib.dbMemory;
using participle.kernel.word;

namespace participle.lib.serch
{
    public class WordDatamanage
    {
        private datanode<user> nodeworld;//节点数据库
        private String nodename;//节点名字

        private int nodedeep;//节点深度
        //private string linshi;//临时数据，添加
        private int datasize;//数据库的大小
        // private user
        private long allsize;//字的总大小
        public void setAllSize(long k){

            this.allsize = k;
        }
        public void addSize(long d) {
            this.allsize += d;
        
        }
        public long getAllSize() {

            return this.allsize;
        
        }
        private WordDatamanage(string dd)
        {
            this.nodeworld = new datanode<user>(dd);
            this.nodename = dd;
            this.datasize = 0;
            // this.linshi = null;
            this.nodedeep = 0;

        }
        public static WordDatamanage datamanageone(string md)
        {

            return new WordDatamanage(md);

        }//设置节点姓名
        public void setnodename(string jiedianname)
        {

            this.nodename = jiedianname;

        }
        //获得节点名字
        public string getnodename()
        {
            return this.nodename;
        }
        //设置节点的库
        public void setnodeflag(List<String> mm)
        {

            //this.nodeflag = mm;
        }
        //搜索节点数据
        int ffff = 0;
        private int i1 = 0;


        //搜索数据专用
        private datanode<user> serchnode_(string usename, datanode<user> mm)
        {
            // Console.Write("循环第{0}次",i1++);

            Char[] ma = usename.ToCharArray();
            if (ma.Length == 0) { return mm; }
            string nameflag = ma[0].ToString();
            datanode<user> ff1 = mm;
            datanode<user> ss = null;
            List<datanode<user>> m1 = mm.getdatakuobject();
            Boolean fm = false;
            if (nameflag.Length != 0)
            {
                for (int i = 0; i < mm.getdataku(); i++)
                {
                    datanode<user> m2 = m1.ElementAt(i);

                    if (m2.getname() == nameflag)
                    {
                        fm = true;
                        ss = m2;
                        break;
                    }

                }

                if (fm)
                {
                    nameflag = usename.Substring(1);
                    Console.Write("\ndigui第{0}次", ffff++);
                    return serchnode_(nameflag, ss);
                }
                else
                {
                    //Console.Write("\n循环第{0}次", i1++);
                    //ss = mm;
                    //  ss.createnode(nameflag, null, null);
                    // mm.addnode();
                    // nameflag = usename.Substring(1);
                    // serchnode_(nameflag, ss.getnextnode());
                    return mm = null;
                }
                //return ff1;

            }
            else return mm;



        }
        // 搜索添加数据专用
        private datanode<user> serchnode(string usename, datanode<user> mm)
        {
            // Console.Write("循环第{0}次",i1++);

            Char[] ma = usename.ToCharArray();
            if (ma.Length == 0) { return mm; }
            string nameflag = ma[0].ToString();
            datanode<user> ff1 = mm;
            datanode<user> ss = null;
            List<datanode<user>> m1 = mm.getdatakuobject();
            Boolean fm = false;
            if (nameflag.Length != 0)
            {
                for (int i = 0; i < mm.getdataku(); i++)
                {
                    datanode<user> m2 = m1.ElementAt(i);

                    if (m2.getname() == nameflag)
                    {
                        fm = true;
                        ss = m2;
                        break;
                    }

                }

                if (fm)
                {
                    nameflag = usename.Substring(1);
                    Console.Write("\ndigui第{0}次", ffff++);
                    return serchnode(nameflag, ss);
                }
                else
                {
                    Console.Write("\n循环第{0}次", i1++);
                    ss = mm;
                    user temp = new user();
                    ss.createnode(nameflag, temp, null);
                    // mm.addnode();
                    nameflag = usename.Substring(1);
                    return serchnode(nameflag, ss.getnextnode());

                }
                // return ff1;

            }
            else return mm;



        }
        //搜索添加数据
        public user serchdata(string usename)
        {
            return serchnode(usename, this.nodeworld).serchnodedataT();
        }
        //搜索数据专用
        public user serchdata_(string usename)
        {
            //  serchnode_(usename, this.nodeworld).serchnodedataT();
            datanode<user> mk = serchnode_(usename, this.nodeworld);
            if (mk == null)
            {
                return null;

            }
            else
            {

                return mk.serchnodedataT();
            }

        }
        public datanode<user> add_data1(string n)
        {
            return serchnode(n, this.nodeworld);

        }

        /*
         处理serch
         */
        //add()数据
        public void serch_add_data(string name, Word mm)
        {


            user muser = serchdata(name);

            serchdatasmessage mserchmassage = muser.mserch;

            mserchmassage.addnewdata(mm, mserchmassage.getmsderchdatanode());

        }


        //搜索返回数据
        public Word serch_result(string username, string wordstr)
        {

            user muser = serchdata_(username);
            if (muser == null)
            {
                return null;
            }
            serchdatasmessage mserch = muser.mserch;

            if (mserch == null) {

                return null;
            
            }

            Word mword = mserch.serchofword(mserch.getmsderchdatanode(), wordstr);


            return mword;
           
        }


        //添加数据
        public Boolean addnodedata(string usename, Object mobject)
        {
            datanode<user> mg = serchnode(usename, this.nodeworld);
            if (mg == null)
                return false;
            else
            {
                mg.setobject(mobject);
                return true;

            }
        }



        public Boolean addnodedata(string usename, user f)
        {
            datanode<user> mg = serchnode(usename, this.nodeworld);
            if (mg == null)
                return false;
            else
            {
                mg.setT(f);
                return true;

            }
        }
        //更新数据
        public Boolean updatenodeT(datanode<user> mm, string usename, user d)
        {

            datanode<user> mg = serchnode(usename, mm);
            if (mg == null)
                return false;
            else
            {
                mg.setobject(d);
                return true;

            }


        }

        public Boolean updatenodeT(datanode<user> mm, string usename, user dd, Object mmm)
        {

            datanode<user> mg = serchnode(usename, mm);
            if (mg == null)
                return false;
            else
            {
                mg.updatanodedata(dd, mmm);
                return true;

            }


        }
        //遍历
        public datanode<user> Ergodic(datanode<user> j)
        {

            if (j.getdatakuobject() == null)
            {


                return j;

            }
            else
            {

                List<datanode<user>> mlist = j.getdatakuobject();
                for (int i = 0; i < mlist.Count; i++)
                {





                }


                return j;





            }




        }

        //分类词管理
        private AssortmentDatamanage getAssortmentDatamanage(string username, string wordstr)
        {
            Word mword = serch_result(username, wordstr);

            if (mword == null) {

                return null;
            }
            AssortmentDatamanage massort = mword.getAssortment();

            return massort;
        }
        //分类词
        public Assortment getAssortment(string username, string wordstr, string assortname, string assortpinyin)
        {
            AssortmentDatamanage mmm = getAssortmentDatamanage(username, wordstr);

           Assortment mass =  mmm.serch_result(assortname, assortpinyin);

           return null;
        
        }



    }
   



    //shop搜索结果


   

   //适配器user
    public class user
    {


        public string name;
        public int f;
        public SortedDictionary<string, string> msort;
        public serchdatasmessage mserch;
        public user(serchdatasmessage jk)
        {
            this.name = "ll";
            this.f = 0;
            this.msort = new SortedDictionary<string, string>();
            this.mserch = jk;
        }

        public user()
        {
            this.name = "ll";
            this.f = 0;
            this.msort = new SortedDictionary<string, string>();
            this.mserch = new serchdatasmessage();
        }





    }
    //数据类型
    public class data_type
    {
        public WordDatamanage data;
        public mysql mmysql;





    }

  
    //错误报告
    public class myerror
    {
        public string name;
        public string error_leve;
        public int error_unm;
        public myerror(string name, string error_leve, int unm)
        {
            this.name = name;
            this.error_leve = error_leve;
            this.error_unm = unm;


        }
        public string tostring1()
        {

            return this.name + ":" + this.error_leve + ":" + this.error_unm;


        }
        
    }
    
}





