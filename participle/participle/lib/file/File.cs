using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace participle.lib.file
{
    class FileRead
    {
        private string path;
        private StreamReader mreader;//读取文本文件
        public FileRead(string path) {
            this.path = path;
            this.mreader = new StreamReader(path,Encoding.UTF8);
        }

        //读取全部数据
        public StringBuilder read() {
            StringBuilder m = new StringBuilder();

            
            if (this.mreader == null)
            {
                return new StringBuilder(); 
            
            }
            try
            {
                while (this.mreader.Peek() >= 0)
                {
                    m.Append(this.mreader.ReadLine());

                }
            }catch(OutOfMemoryException f){

                return null;
            }

            return m;
        }

        public void close() {

            this.mreader.Close();
        
        }
    }

    public class FileWrite {

        private string path;
        private StreamWriter mwrite;
        public FileWrite(string path) {

            this.path = path;
            mwrite = new StreamWriter(this.path);
        
        }

        public bool write(string data) {

            if (data.Length == 0) { 
            
            return false;
            }

            try {

                this.mwrite.Write(data);
            
            }catch(Exception e){

                return false;
            
            }
            return true;
        
        }
        public void close() {

            this.mwrite.Close();
        
        }

    } 
}
