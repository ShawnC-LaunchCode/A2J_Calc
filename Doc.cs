using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2J_Calc
{
    public class Doc
    {
        public string title;
        public int numPages;
        public int numFields;
        
        public bool needFast;
        public bool isWordFormat;

        public Doc(int numPages, int numFields, bool needFast, bool isWordFormat, string title = "None")
        {
            this.numPages = numPages;
            this.numFields = numFields;
            
            this.needFast = needFast;
            this.isWordFormat = isWordFormat;
            this.title = title;
        }

        public override string ToString()
        {
            string output = "";
            output += "numPages:" + this.numPages;
            output += "\nnumFields:" + this.numFields;
           
            output += "\nneedFast:" + this.needFast;
            output += "\nneedWord" + this.isWordFormat;


            return output;
        }
    }
}
