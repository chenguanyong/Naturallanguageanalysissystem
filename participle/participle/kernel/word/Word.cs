using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using participle.lib.dbMemory;

namespace participle.kernel.word
{
    public class Word : baseWord
    {
        private static object m;
        private string words;//字符串
        private float chance;//概率
        private int natureWord;//词性
        private List<string> similarword;//近义词
        private AssortmentDatamanage massort;//分类词管理
        public Word()
        {
            m = new object();
            this.words = "";
            this.chance = 0;
            this.massort =  AssortmentDatamanage.datamanageone("a");
        }
        public Word(string name)
        {
            m = new object();
            this.words = name;
            this.chance = 0;
            this.massort = AssortmentDatamanage.datamanageone("a");
        }
        //得到分类词的管理
        public AssortmentDatamanage getAssortment() {

            return this.massort;
        
        }


        //设置字符
        public void setWord(string str)
        {
            lock (m)
            {
                this.words = str;
            }

        }
        //获取字符
        public string getWord()
        {
            return this.words;
        }
        //添加概率
        public void addChance()
        {
            lock (m)
            {
                this.chance++;
            }
        }
        //减少概率
        public void red()
        {
            lock (m) { this.chance--; }
        }
        //保存
        public bool save()
        {
            return false;
        }
        //获取概率
        public float getChance()
        {
            return this.chance;
        }
        //获取分类词; 根据已有的分类词assort
        public Assortment getAssortment(string assortpinyin, string asssort) {



            return this.massort.serch_result(assortpinyin, asssort);
        
        
        
        }

        //获取分类词链表。
        //public AssortmentDatamanage 

    }
    interface baseWord
    {

        bool save();
        string getWord();
        void setWord(string str);

    }
}
