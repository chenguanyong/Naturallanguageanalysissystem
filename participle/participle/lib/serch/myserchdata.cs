using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using participle.kernel.word;
using participle.lib.dbMemory;

namespace participle.lib.serch
{
    //词语节点
    public class serchdatanode
    {
        private serchdatanode nextserchdatanode;//下一个节点
        private serchdatanode befserchdatanode;//上一个节点
        private Word mwork;//词语
        


        
        public void setbfsetchdatanode(serchdatanode mma)
        {
            this.befserchdatanode = mma;
        }
        public serchdatanode getbfserchdatanode()
        {

            return this.befserchdatanode;


        }
        public serchdatanode(Word mk)
        {

            this.nextserchdatanode = null;
            this.befserchdatanode = null;
            this.mwork = mk;
           

        }
        public serchdatanode()
        {

            this.nextserchdatanode = null;
            this.befserchdatanode = null;
            this.mwork = null;
             

        }

        public serchdatanode(string name)
        {


            this.nextserchdatanode = null;
            this.mwork = new Word(name);

        }






        //属性的转换成数字

        //huoquzuidazhi


        //添加文章
        public Boolean addserchdatanode(Word am)
        {

            if (this.nextserchdatanode == null)
            {
                serchdatanode mma = new serchdatanode(am);

                this.nextserchdatanode = mma;
                return true;
            }
            else
                return false;

        }//添加商品

        public void setnextserchdatanode(serchdatanode mm)
        {
            this.nextserchdatanode = mm;
        }
        public serchdatanode getnextserchdatanode()
        {
            return this.nextserchdatanode;

        }
        public void setuser_work(Word ko)
        {

            this.mwork = ko;

        }
        public Word getuser_work()
        {

            return this.mwork;
        }



    }



    //管理链表
    public class serchdatasmessage
    {
        private serchdatanode mserchdatanode;//管理链表 
        private serchdatanode lastserchdatanode;//最后一个节点
        public serchdatanode getmsderchdatanode()
        {

            return this.mserchdatanode;
        }
        public serchdatasmessage(serchdatanode mm)
        {
            this.mserchdatanode = mm;



        }
        public serchdatasmessage()
        {
            this.mserchdatanode = new serchdatanode();

            this.lastserchdatanode = this.mserchdatanode;

        }
        public serchdatasmessage(Word kk)
        {

            this.mserchdatanode = new serchdatanode(kk);


        }
        //添加数据文章
        public Boolean addnewdata(Word nn, serchdatanode ff)
        {

            if (ff.getuser_work() == null)
            {
                ff.setuser_work(nn);
                return true;
            }
            else
            {
                serchdatanode na = ff.getnextserchdatanode();
                if (na == null)
                {
                    na = new serchdatanode(nn);
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


        public Boolean deletenode(serchdatanode mm, float gailv) {

            Word mword = mm.getuser_work();

            if (mword.getChance() < gailv)
            {
                serchdatanode beforenode = mm.getbfserchdatanode();
                beforenode.setnextserchdatanode(mm.getnextserchdatanode());
                mm = null;
                return true;



            }
            else
            {
                return deletenode(mm.getnextserchdatanode(),  gailv);
            }
        
        
        
        
        
        }


       //搜索相关的词语
        public Word serchofword(serchdatanode mm, string  m2)
        {

            Word mword =mm.getuser_work();

            if ( mword.getWord() == m2)
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
