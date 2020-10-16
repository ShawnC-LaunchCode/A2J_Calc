using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2J_Calc
{
    class Document
    {
        int numPages;
        int numFields;
        bool needFast;
        bool needWord;

        public Document(int numPages, int numFields, bool needFast, bool needWord)
        {
            this.numPages = numPages;
            this.numFields = numFields;
            this.needFast = needFast;
            this.needWord = needWord;
        }
    }
}
