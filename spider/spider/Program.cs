using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using spider.APP.run;

namespace spider
{
    class Program
    {
        static void Main(string[] args)
        {

          find_site mm = new find_site();

          mm.start();

            Console.Write("启动成功");
            Console.Read();
        }
    }
}
