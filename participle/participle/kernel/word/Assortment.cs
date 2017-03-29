using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace participle.kernel.word
{
  public  class Assortment
    {
      private string word;//分类词
      private float probability;//概率
      private string pinyin;//拼音
      private object lockobject = new object();
      private SortedDictionary<string, string> similarWord;
      public Assortment() {

          this.word = "";
          this.probability = 0;
          this.pinyin = "";
          this.similarWord = new SortedDictionary<string, string>();
      
      }
      public Assortment(string word, string pinyin) {
          this.pinyin = pinyin;
          this.word = word;
          this.probability = 0;
          this.similarWord = new SortedDictionary<string,string>();
      
      }
      //设置近义词
      public void setSim(string word, string pinyin) {

          lock (lockobject)
          {
              this.similarWord.Add(pinyin, word);
          }
      }
      //获取近义词
      public SortedDictionary<string, string> getSim() {

          return this.similarWord;
      }
      //由拼音获取近义词

      public string getSimByPinyin(string pinyin) {
          string word = "";
          try
          {
              word = this.similarWord[pinyin];
          }
          catch (Exception g) {

              return "";
          }
          return word;
      
      }
      //添加概率
      public void AddPro(float fen) {
          lock (lockobject)
          {
              this.probability += fen;
          }
      
      }
      //获取概率
      public float getPro() {

          return this.probability;
      }
      //设置分类词
      public void setWord(string word) {
          lock (lockobject)
          {
              this.word = word;
          }
      }
      //获取分类词
      public string getWord() {

          return this.word;
      }
      //设置拼音
      public void setPinyin(string pinyin) {
          lock(lockobject){
            this.pinyin = pinyin;
          }
      }
      //获取拼音
      public string getPinyin() {
          return this.pinyin;
      }
    }
}
