using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using participle.lib.serch;
using participle.kernel.word;

namespace participle.kernel.AnalysisWords
{
    public struct PipWord
    {
        public int num;//序号
        public float mark;//分数
        public string word;//单词
        public string pinyin;//拼音
    }
    public class AnalysisWord
    {
        private StringBuilder alltxt;
        private static int txtcount;
        private static int txtlength;
        private List<string> mlists;
        private WordDatamanage mainassort;
        //设置待处理文本
        public void setAlltxt(string txt)
        {
            this.alltxt = new StringBuilder(txt);
            txtlength = this.alltxt.Length;
        }
        public AnalysisWord(WordDatamanage wordassort)
        {
            this.alltxt = new StringBuilder();
            txtcount = 0;
            txtlength = this.alltxt.Length;
            this.mlists = new List<string>();
            this.mainassort = wordassort;

        }
        public AnalysisWord(String txt, WordDatamanage wordassort)
        {
            this.alltxt = new StringBuilder(txt);
            txtcount = 0;
            txtlength = this.alltxt.Length;
            this.mlists = new List<string>();
            this.mainassort = wordassort;
        }
        //分析
        public Boolean Analysis()
        {

            while (true)
            {
                StringBuilder str = Punctuation();
                if (str == null)
                {
                    break;
                }
                int str_count = str.Length;
                if (str_count == 0) { break; }
                StringBuilder mm = new StringBuilder();
                for (int i = 0; i < str_count; i++)
                {

                    mm.Append(str[i]);

                    if (i % 4 == 0 || str[i].ToString() == " ")
                    {

                        int mm_length = mm.Length;

                        for (int a = mm_length - 1; a > 0; a--)
                        {

                            string gg = mm.Remove(a, 1).ToString();
                            //添加到dbmeny中
                            string ping = GetPinyin.getAllPinYin(gg);
                            Word m = new Word(gg);
                                                       
                            this.mainassort.serch_add_data(ping, m);
                        }

                    }
                }

            }
            return false;
        }
        //分词
        public List<string> participle()
        {
            PipWord gg = new PipWord();
            while (true)
            {
                StringBuilder str = Punctuation();
                if (str == null)
                {
                    break;
                }
                int str_length = str.Length;
                List<PipWord> mlist = new List<PipWord>();
                for (int i = 0; i < str_length; )
                {
                    int a = i + 1;
                    if (str[a].ToString() != " ")
                    {
                        if (a < str_length)
                        {

                            gg.num = a;
                            gg.word = str[i].ToString() + str[a];
                            gg.pinyin = GetPinyin.getAllPinYin(gg.word);
                            Word mword = this.mainassort.serch_result(gg.pinyin, gg.word);
                            if (mword == null) {
                                gg.mark = 0;
                            
                            }
                            gg.mark = mword.getChance();//这里是获取分数的函数
                            if (gg.mark != 0) { mlist.Add(gg); }

                        }
                    }
                    int a1 = i + 2;
                    if (a1 < str_length)
                    {
                        gg.num = a1;

                        gg.word = str[i].ToString() + str[a] + str[a1];
                        gg.pinyin = GetPinyin.getAllPinYin(gg.word);
                        Word mword = this.mainassort.serch_result(gg.pinyin, gg.word);
                        if (mword == null)
                        {
                            gg.mark = 0;

                        }
                        gg.mark = mword.getChance();//这里是获取分数的函数
                        if (gg.mark != 0) { mlist.Add(gg); }

                    }
                    int a3 = i + 3;

                    if (a3 < str_length)
                    {
                        gg.num = a3;
                        
                        gg.word = str[i].ToString() + str[a] + str[a1] + str[a3];
                        gg.pinyin = GetPinyin.getAllPinYin(gg.word);
                        Word mword = this.mainassort.serch_result(gg.pinyin, gg.word);
                        if (mword == null)
                        {
                            gg.mark = 0;

                        }
                        gg.mark = mword.getChance();//这里是获取分数的函数
                        if (gg.mark != 0) { mlist.Add(gg); }


                    }
                    PipWord jj = new PipWord();
                    jj = mlist[0];
                    for (int ii = 0; ii < mlist.Count - 1; ii++)
                    {

                        if (jj.mark <= mlist[ii + 1].mark)
                        {

                            jj = mlist[ii + 1];
                        }


                    }

                    this.mlists.Add(jj.word);
                    i = jj.num;



                }



            }


            return new List<string>();
        }
        //初始化PipWord
        protected PipWord initPip(string g)
        {


            return new PipWord();
        }
        //断句
        protected StringBuilder Punctuation()
        {
            StringBuilder mtxt = new StringBuilder();
            while (txtcount != txtlength)
            {
                mtxt.Append(this.alltxt[txtcount]);
                txtcount++;
            }
            return this.alltxt;
        }

    }


}
