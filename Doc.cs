using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2J_Calc
{
    public class Doc
    {
        public int numPages;
        public int numFields;
        public int numRepeated;
        public bool needFast;
        public bool needWord;

        public Doc(int numPages, int numFields, int numRepeated, bool needFast, bool needWord)
        {
            this.numPages = numPages;
            this.numFields = numFields;
            this.numRepeated = numRepeated;
            this.needFast = needFast;
            this.needWord = needWord;
        }

        public override string ToString()
        {
            string output = "";
            output += "numPages:" + this.numPages;
            output += "\nnumFields:" + this.numFields;
            output += "\nnumRepeated:" + this.numRepeated;
            output += "\nneedFast:" + this.needFast;
            output += "\nneedWord" + this.needWord;


            return output;
        }
    }
}
