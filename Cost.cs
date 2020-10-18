using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2J_Calc
{
    public static class Cost
    {
        public static int Rush = 10; //Less than 30 days upcharge

        public static Dictionary<string, int> DocTypeUpcharge = new Dictionary<string, int>
        {
            {"AllPDF",0 },      //no upcharge for all PDF
            {"MixedWord", 1 },  //1% for mixed types of PDF & Word
            {"AllWord", 2 }     //2% for all Word docs
        };

        public static Dictionary<string, int> PageCost = new Dictionary<string, int>
        {
            { "1To5", 4 },
            { "6To10", 6 },
            { "11To20", 8 },
            { "21To30", 12 },
            { "31To40", 14 },
            { "41To50", 20 } //Anything higher needs custom quote, and shouldnt be getting looked up
        };

        public static Dictionary<string, int> FieldCost1To5 = new Dictionary<string, int>
        {
            { "1To10",2},
            {"10To20",4 },
            {"21To40",6 },
            {"41To50", 8} //Anything beyond 50 needs custom quote, and shouldnt be getting looked up
        };

        public static Dictionary<string, int> FieldCost6To10 = new Dictionary<string, int>
        {
            { "1To10",2},
            {"10To20",4 },
            {"21To40",8 },
            {"41To50", 12} //Anything beyond 50 needs custom quote, and shouldnt be getting looked up
        };

        public static Dictionary<string, int> FieldCost11To20 = new Dictionary<string, int>
        {
            { "1To10",3},
            {"10To20",6 },
            {"21To40",10 },
            {"41To50", 14} //Anything beyond 50 needs custom quote, and shouldnt be getting looked up
        };
        public static Dictionary<string, int> FieldCost21To30 = new Dictionary<string, int>
        {
            { "1To10",3},
            {"10To20",8 },
            {"21To40",14 },
            {"41To50", 17} //Anything beyond 50 needs custom quote, and shouldnt be getting looked up
        };

        public static Dictionary<string, int> FieldCost31To40 = new Dictionary<string, int>
        {
            { "1To10",3},
            {"10To20",8 },
            {"21To40",14 },
            {"41To50", 20} //Anything beyond 50 needs custom quote, and shouldnt be getting looked up
        };

        public static Dictionary<string, int> FieldCost41To50 = new Dictionary<string, int>
        {
            { "1To10",4},
            {"10To20",10 },
            {"21To40",16 },
            {"41To50", 22} //Anything beyond 50 needs custom quote, and shouldnt be getting looked up
        };

    }
}
