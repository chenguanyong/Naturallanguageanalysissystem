using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using participle.kernel.word;

namespace participle.lib.dbMemory
{
    //分类词
    public class Assortmentdatanode
    {
        private Assortmentdatanode nextserchdatanode;//下一个节点
        private Assortmentdatanode befserchdatanode;//上一个节点
        private Assortment  assort;//词语
       



        public void setbfsetchdatanode(Assortmentdatanode mma)
        {
            this.befserchdatanode = mma;
        }
        public Assortmentdatanode getbfserchdatanode()
        {

            return this.befserchdatanode;


        }
        public Assortmentdatanode(Assortment mk)
        {

            this.nextserchdatanode = null;
            this.befserchdatanode = null;
            this.assort = mk;
            

        }
        public Assortmentdatanode()
        {

            this.nextserchdatanode = null;
            this.befserchdatanode = null;
            this.assort = null;


        }

        public Assortmentdatanode(string name, string pinyin)
        {


            this.nextserchdatanode = null;
            this.assort = new Assortment(name, pinyin);

        }



        //添加文章
        public Boolean addserchdatanode(Assortment am)
        {

            if (this.nextserchdatanode == null)
            {
                Assortmentdatanode mma = new Assortmentdatanode(am);

                this.nextserchdatanode = mma;
                return true;
            }
            else
                return false;

        }//添加商品
        //删除节点
        public Boolean delelteserchdatanode()
        {

            if (this.nextserchdatanode != null)
            {
                //serchdatanode mma = new serchdatanode(am);

                this.nextserchdatanode = null;
                return true;
            }
            else
                return false;


        }
        public void setnextserchdatanode(Assortmentdatanode mm)
        {
            this.nextserchdatanode = mm;
        }
        public Assortmentdatanode getnextserchdatanode()
        {
            return this.nextserchdatanode;

        }
        public void setuser_work(Assortment ko)
        {

            this.assort = ko;

        }
        public Assortment getuser_work()
        {

            return this.assort;
        }



    }




    //管理链表
    public class Assortmentmessage
    {
        private Assortmentdatanode mserchdatanode;//管理链表 
        private Assortmentdatanode lastserchdatanode;//最后一个节点
        public Assortmentdatanode getmsderchdatanode()
        {

            return this.mserchdatanode;
        }
        public Assortmentmessage(Assortmentdatanode mm)
        {
            this.mserchdatanode = mm;



        }
        public Assortmentmessage()
        {
            this.mserchdatanode = new Assortmentdatanode();

            this.lastserchdatanode = this.mserchdatanode;

        }
        public Assortmentmessage(Assortment kk)
        {

            this.mserchdatanode = new Assortmentdatanode(kk);


        }
        //添加数据文章
        public Boolean addnewdata(Assortment nn, Assortmentdatanode ff)
        {

            if (ff.getuser_work() == null)
            {
                ff.setuser_work(nn);
                return true;
            }
            else
            {
                Assortmentdatanode na = ff.getnextserchdatanode();
                if (na == null)
                {
                    na = new Assortmentdatanode(nn);
                    return true;

                }
                else
                {

                    return addnewdata(nn, na);

                }

                // return false;

            }




        }
        //删除节点


        public Boolean deletenode(Assortmentdatanode mm, float gailv)
        {

            Assortment mword = mm.getuser_work();

            if (mword.getPro() < gailv)
            {
                Assortmentdatanode beforenode = mm.getbfserchdatanode();
                beforenode.setnextserchdatanode(mm.getnextserchdatanode());
                mm = null;
                return true;



            }
            else
            {
                return deletenode(mm.getnextserchdatanode(), gailv);
            }





        }


        //搜索相关的词语
        public Assortment serchofword(Assortmentdatanode mm, string m2)
        {

            Assortment mword = mm.getuser_work();

            if (mword.getWord() == m2)
            {

                return mword;



            }
            else
            {
                return serchofword(mm.getnextserchdatanode(), m2);
            }

        }//





    }
}
