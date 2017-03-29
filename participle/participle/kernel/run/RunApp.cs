using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using participle.kernel.AnalysisWords;

namespace participle.kernel.run
{
    //app
    public class RunWord
    {

        private AnalysisWord manly;
        public RunWord()
        {
            this.manly = new AnalysisWord();

        }
        public RunWord(string txt)
        {
            this.manly = new AnalysisWord(txt);
        }

    }
}
