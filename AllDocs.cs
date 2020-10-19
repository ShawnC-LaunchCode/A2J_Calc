using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

 namespace A2J_Calc
{
    public static class AllDocs
    {
        public static int costForPages;
        public static int costForFields;
        
        public static int percentWordUpcharge;
        public static int costWordUpcharge;
        public static int costGrandTotal;
        public static List<Doc> masterList = new List<Doc>();

        public static int TotalPages()
        {
            int output = 0;
            foreach (var thing in masterList)
            {
                output += thing.numPages;
            }
            return output;
        }

        public static int TotalFields()
        {
            int output = 0;
            foreach (var thing in masterList)
            {
                output += thing.numFields;
            }
            return output;
        }

        public static bool NeedRush()
        {
            bool output = false;
            foreach (var thing in masterList)
            {
                if (thing.needFast)
                {
                    output = true;
                    break;
                }
            }
            return output;
        }

        public static int PDFCount()
        {
            int output = 0;
            foreach (var thing in masterList)
            {
                if (!thing.needWord)
                {
                    output += 1;
                }
            }
            return output;
        }

        public static int WordCount()
        {
            int output = 0;
            foreach (var thing in masterList)
            {
                if (thing.needWord)
                {
                    output += 1;
                }
            }
            return output;
        }


        public static int CostLookupPages()
        {
            int output=0;
            int totPages = AllDocs.TotalPages();
          
            switch (totPages)
            {
                case 0:
                    output = Cost.PageCost["Zero"]*Cost.Hourly();
                    break;
                case int n when (n > 0 && n <= 5):
                    output = Cost.PageCost["1To5"] * Cost.Hourly();
                    break;
                case int n when (n > 5 && n <= 10):
                    output = Cost.PageCost["6To10"] * Cost.Hourly();
                    break;
                case int n when (n > 10 && n <= 20):
                    output = Cost.PageCost["11To20"] * Cost.Hourly();
                    break;
                case int n when (n > 20 && n <= 30):    
                    output = Cost.PageCost["21To30"] * Cost.Hourly();
                    break;
                case int n when (n > 30 && n <= 40):
                    output = Cost.PageCost["31To40"] * Cost.Hourly();
                    break;
                case int n when (n > 40 && n <= 50):
                    output = Cost.PageCost["41To50"] * Cost.Hourly();
                    break;
            }
            return output;
        }

        public static int CostLookupFields()
        {
            int output = 0;
            int totFields = AllDocs.TotalFields();
            int totPages = AllDocs.TotalPages();
            Dictionary<string,int> lookupDict;
            string lookupKey;

           
            switch (totPages) //set which lookup table to use, based on total pages
            {
                case int n when (n >= 0 && n <= 5): 
                    lookupDict = Cost.FieldCost1To5;
                    break;
                case int n when (n > 5 && n <= 10):
                    lookupDict = Cost.FieldCost6To10;
                    break;
                case int n when (n > 10 && n <= 20):
                    lookupDict = Cost.FieldCost11To20;
                    break;
                case int n when (n > 20 && n <= 30):
                    lookupDict = Cost.FieldCost21To30;
                    break;
                case int n when (n > 30 && n <= 40):
                    lookupDict = Cost.FieldCost31To40;
                    break;
                case int n when (n > 40 && n <= 50):
                    lookupDict = Cost.FieldCost41To50;
                    break;
                default:
                    lookupDict = Cost.FieldCost1To5; //not used, but needed "default" to mold scope
                    break;
            }

            switch (totFields)
            {
                case 0:
                    lookupKey = "Zero";
                    break;
                case int n when (n > 0 && n < 10):
                    lookupKey = "1To10";
                    break;
                case int n when (n >= 10 && n <= 20):
                    lookupKey = "10To20";
                    break;
                case int n when (n > 20 && n <= 40):
                    lookupKey = "21To40";
                    break;
                case int n when (n > 40 && n <= 50):
                    lookupKey = "41To50";
                    break;
                default:
                    lookupKey = "Zero"; // not used, but needed "default" to mold scope
                    break;
            }

            output = (lookupDict[lookupKey]*Cost.Hourly());
            
            return output;
        }

        public static string CostRush()
        {
            string output = "";

            //TODO

            return output;
        }
       
    }

   
}
