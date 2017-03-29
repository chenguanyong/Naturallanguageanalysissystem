using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using participle.lib.data;
using participle.kernel.word;
using participle.lib.serch;

namespace participle.lib.dbMemory
{
    //分类词管理
    public class AssortmentDatamanage
    {
        private datanode<Assort> nodeworld;//节点数据库
        private String nodename;//节点名字
        private int nodedeep;//节点深度
        //private string linshi;//临时数据，添加
        private int datasize;//数据库的大小
        // private Assort
        private long allsize;//字的总大小
        public void setAllSize(long k)
        {

            this.allsize = k;
        }
        public void addSize(long d)
        {
            this.allsize += d;

        }
        public long getAllSize()
        {
            return this.allsize;

        }
        private AssortmentDatamanage(string dd)
        {
            this.nodeworld = new datanode<Assort>(dd);
            this.nodename = dd;
            this.datasize = 0;
            // this.linshi = null;
            this.nodedeep = 0;
        }
        public static AssortmentDatamanage datamanageone(string md)
        {

            return new AssortmentDatamanage(md);

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
        private datanode<Assort> serchnode_(string usename, datanode<Assort> mm)
        {
            // Console.Write("循环第{0}次",i1++);

            Char[] ma = usename.ToCharArray();
            if (ma.Length == 0) { return mm; }
            string nameflag = ma[0].ToString();
            datanode<Assort> ff1 = mm;
            datanode<Assort> ss = null;
            List<datanode<Assort>> m1 = mm.getdatakuobject();
            Boolean fm = false;
            if (nameflag.Length != 0)
            {
                for (int i = 0; i < mm.getdataku(); i++)
                {
                    datanode<Assort> m2 = m1.ElementAt(i);

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
        private datanode<Assort> serchnode(string usename, datanode<Assort> mm)
        {
            // Console.Write("循环第{0}次",i1++);

            Char[] ma = usename.ToCharArray();
            if (ma.Length == 0) { return mm; }
            string nameflag = ma[0].ToString();
            datanode<Assort> ff1 = mm;
            datanode<Assort> ss = null;
            List<datanode<Assort>> m1 = mm.getdatakuobject();
            Boolean fm = false;
            if (nameflag.Length != 0)
            {
                for (int i = 0; i < mm.getdataku(); i++)
                {
                    datanode<Assort> m2 = m1.ElementAt(i);

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
                    Assort temp = new Assort();
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
        public Assort serchdata(string usename)
        {
            return serchnode(usename, this.nodeworld).serchnodedataT();
        }
        //搜索数据专用
        public Assort serchdata_(string usename)
        {
            //  serchnode_(usename, this.nodeworld).serchnodedataT();
            datanode<Assort> mk = serchnode_(usename, this.nodeworld);
            if (mk == null)
            {
                return null;

            }
            else
            {

                return mk.serchnodedataT();
            }

        }
        public datanode<Assort> add_data1(string n)
        {
            return serchnode(n, this.nodeworld);

        }


        //add()数据
        public void serch_add_data(string name, Assortment mm)
        {


            Assort muser = serchdata(name);

            Assortmentmessage mserchmassage = muser.mserch;

            mserchmassage.addnewdata(mm, mserchmassage.getmsderchdatanode());

        }


        //搜索返回数据
        public Assortment serch_result(string username, string wordstr)
        {

            Assort muser = serchdata_(username);
            if (muser == null)
            {
                return null;
            }
            Assortmentmessage mserch = muser.mserch;

            if (mserch == null)
            {

                return null;

            }

            Assortment mword = mserch.serchofword(mserch.getmsderchdatanode(), wordstr);


            return mword;

        }


        //添加数据
        public Boolean addnodedata(string usename, Object mobject)
        {
            datanode<Assort> mg = serchnode(usename, this.nodeworld);
            if (mg == null)
                return false;
            else
            {
                mg.setobject(mobject);
                return true;

            }
        }



        public Boolean addnodedata(string usename, Assort f)
        {
            datanode<Assort> mg = serchnode(usename, this.nodeworld);
            if (mg == null)
                return false;
            else
            {
                mg.setT(f);
                return true;

            }
        }
        //更新数据
        public Boolean updatenodeT(datanode<Assort> mm, string usename, Assort d)
        {

            datanode<Assort> mg = serchnode(usename, mm);
            if (mg == null)
                return false;
            else
            {
                mg.setobject(d);
                return true;

            }


        }

        public Boolean updatenodeT(datanode<Assort> mm, string usename, Assort dd, Object mmm)
        {

            datanode<Assort> mg = serchnode(usename, mm);
            if (mg == null)
                return false;
            else
            {
                mg.updatanodedata(dd, mmm);
                return true;

            }


        }
        //遍历
        public datanode<Assort> Ergodic(datanode<Assort> j)
        {

            if (j.getdatakuobject() == null)
            {


                return j;

            }
            else
            {

                List<datanode<Assort>> mlist = j.getdatakuobject();
                for (int i = 0; i < mlist.Count; i++)
                {





                }


                return j;





            }




        }



    }

        //分类词适配器
    public class Assort
    {


        public string name;
        public int f;
        public SortedDictionary<string, string> msort;
        public Assortmentmessage mserch;
        public Assort(Assortmentmessage jk)
        {
            this.name = "ll";
            this.f = 0;
            this.msort = new SortedDictionary<string, string>();
            this.mserch = jk;
        }

        public Assort()
        {
            this.name = "ll";
            this.f = 0;
            this.msort = new SortedDictionary<string, string>();
            this.mserch = new Assortmentmessage();
        }





    }


    public class datanode<T>
    {
        private string name;//节点名字
        private char flag;
        private List<datanode<T>> dataku;//存储数据 的库
        private datanode<T> nextnode;//下一个节点
        private Int16 nodesize;//节点7大小
        private object mobject;//直接对象
        private T mt;//挂载数据
        public List<datanode<T>> getdatakuobject()
        {

            return this.dataku;
        }
        public int getdataku()
        {
            return dataku.Count;
        }
        public void setflag(char f)
        {

            this.flag = f;
        }
        public char getflag()
        {

            return this.flag;
        }
        public datanode(string name)
        {
            this.dataku = new List<datanode<T>>();//实例化数据库
            this.name = name;
            this.nodesize = 0;
            this.mobject = null;
            // this.mt =null;
        }

        public datanode(string name, T m2, object mobject)
        {
            this.dataku = new List<datanode<T>>();//实例化数据库
            this.name = name;
            this.nodesize = 0;
            this.mobject = null;
            this.mt = m2;
            this.mobject = mobject;

        }
        public void addnode()
        {
            this.dataku.Add(nextnode);
        }
        public void setobject(Object m11)
        {
            this.mobject = m11;

        }
        public void setT(T m11)
        {
            this.mt = m11;

        }

        //设置节点的名字
        public void setname(string m)
        {

            this.name = m;
        }//获取节点的名字
        public string getname()
        {

            return this.name;
        }
        public Int16 getsize()
        {

            this.nodesize = (Int16)dataku.Count;//获取数据库中的实际数据
            return this.nodesize;
        }
        public Boolean createnode(string f, T mm, object ma)
        {

            this.nextnode = new datanode<T>(f, mm, ma);//创建新的节点；
            dataku.Add(this.nextnode);
            Console.Write("\njiedianmingzi{0}节点库的数量{1}\n", f, dataku.Count);
            return true;


        }
        public Boolean createnode(string ff, T m1)
        {

            return createnode(ff, m1, null);

        }
        public Boolean deletenodedata(int g)
        {

            if (g == 1)
            {
                this.mobject = null;
                return true;

            }
            else if (g == 0) { this.mt = default(T); return true; }
            else return false;

        }
        //更新数据
        public void updatanodedata(T m22, object m)
        {

            this.mt = m22;
            this.mobject = m;

        }
        //搜索数据
        public T serchnodedataT()
        {
            T m;
            if (this.mt == null)
            {
                return m = default(T);
            }
            else return this.mt;

        }
        public datanode<T> getnextnode()
        {

            return this.nextnode;

        }
        public object serchnodedataobject()
        {
            if (this.mobject == null)
            {

                return null;
            }
            else return this.mobject;

        }

        public T getT()
        {

            return this.mt;
        }


    }

   
  
}
