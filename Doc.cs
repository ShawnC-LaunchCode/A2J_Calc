using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2J_Calc
{
    class Doc
    {
        int numPages;
        int numFields;
        int numRepeated;
        bool needFast;
        bool needWord;

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
