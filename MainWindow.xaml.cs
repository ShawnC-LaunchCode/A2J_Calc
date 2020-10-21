using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace A2J_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();

            AllDocs.currentDocNumber = 1;

            InitValuesDoc();
            UpdateTotalsValues();
            //DevValuesRefresh();
            

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DevValuesRefresh()
        {
            //devTotalPages.Text = AllDocs.TotalPages().ToString();

            //devTotalFields.Text = AllDocs.TotalFields().ToString();

            //devBoolRush.Text = AllDocs.NeedRush().ToString();

            //devTotalPDF.Text = AllDocs.PDFCount().ToString();

            //devTotalWord.Text = AllDocs.WordCount().ToString();
        }

        private void InitValuesDoc()
        {
            //Init starting values
            numTotalDocs.Text = AllDocs.masterList.Count().ToString();
            numTotalDocs.IsReadOnly = true;

            stringDocTitle.Text = "";

            numCurrentDocNumber.Text = AllDocs.currentDocNumber.ToString();
            numCurrentDocNumber.IsReadOnly = true;


            txtNumPages.Text = "";
            

            txtNumFields.Text = "";
            boolNeedFast.IsChecked = false;
            boolNeedWord.IsChecked = false;

            stringDocTitle.Focus();
        }

        private void UpdateTotalsValues()
        {
            int total = 0;
            int subTotal = 0;
            if (AllDocs.TotalPages()>50 || AllDocs.TotalFields() > 50)
            {
                //numTotalPagesCost.Text = numTotalFieldsCost.Text = 
                numGrandTotal.Text ="This needs a custom quote.";
                numRushUpchargeAmount.Text = numWordUpchargePercent.Text = numWordUpchargeAmount.Text = "";
                return;
            } else
            {
                //numTotalPagesCost.Text = AllDocs.CostLookupPages().ToString();
                //numTotalFieldsCost.Text = AllDocs.CostLookupFields().ToString();
                total += AllDocs.CostLookupPages() + AllDocs.CostLookupFields();
            }
            
            if (AllDocs.NeedRush())
            {
                numRushUpchargeAmount.Text = (total * ((float)Cost.Rush / 100)).ToString();
                subTotal += (int)(total * (float)Cost.Rush / 100);
            }


            float tempTotal = AllDocs.CostLookupPages() + AllDocs.CostLookupFields();
             
            if (AllDocs.WordCount() != 0)
            {
                if (AllDocs.PDFCount() == 0)
                { // All word docs
                    numWordUpchargePercent.Text = Cost.DocTypeUpcharge["AllWord"].ToString();
                    numWordUpchargeAmount.Text = (tempTotal* Cost.DocTypeUpcharge["AllWord"]/100).ToString();
                    subTotal += (int)(tempTotal * Cost.DocTypeUpcharge["AllWord"] / 100);
                }
                else
                { //Mixed word and PDF
                    numWordUpchargePercent.Text = Cost.DocTypeUpcharge["MixedWord"].ToString();
                    numWordUpchargeAmount.Text = (tempTotal* Cost.DocTypeUpcharge["MixedWord"]/100).ToString();
                    subTotal += (int)(tempTotal * Cost.DocTypeUpcharge["MixedWord"] / 100);
                }
            }
            else
            { //All PDF
                numWordUpchargePercent.Text = Cost.DocTypeUpcharge["AllPDF"].ToString();
                numWordUpchargeAmount.Text = (tempTotal* Cost.DocTypeUpcharge["AllPDF"]/100).ToString();
                subTotal += (int)(tempTotal * Cost.DocTypeUpcharge["AllPDF"] / 100);
            }

            

            if(AllDocs.TotalFields() > 50 || AllDocs.TotalPages() > 50)
            {
                numGrandTotal.Text = "This needs a custom quote.";
            } else
            {
                numGrandTotal.Text = "$" +(total + subTotal).ToString();
            }
        
            numGrandTotal.IsReadOnly = true;

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            
            if (AllDocs.currentDocNumber <= AllDocs.masterList.Count)//if current doc is less than max, update info
            {
                //update current record, if changes or not
                AllDocs.masterList[AllDocs.currentDocNumber - 1] = GatherDocInfo();

                //move to next record
                AllDocs.currentDocNumber++;

                //at new record, master=3, current=4, 
                if (AllDocs.currentDocNumber > AllDocs.masterList.Count())
                {
                    InitValuesDoc();
                }else
                {
                    DisplayDoc(AllDocs.currentDocNumber);
                }
                    
                
                
                
            } else
            {
                AllDocs.masterList.Add(GatherDocInfo());
                AllDocs.currentDocNumber++;
                InitValuesDoc();

            }

            
            UpdateTotalsValues();
            //DevValuesRefresh();
        }

        private void PreviousDoc_Click(object sender, RoutedEventArgs e)
        {

            if (AllDocs.currentDocNumber > 1)
            {
                if (!DocEmpty())
                {
                    AllDocs.masterList[AllDocs.currentDocNumber - 1] = GatherDocInfo();
                }
                  
                AllDocs.currentDocNumber--;
                DisplayDoc(AllDocs.currentDocNumber);
            }
            UpdateTotalsValues();
            //DevValuesRefresh();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            AllDocs.masterList.Clear();
            AllDocs.currentDocNumber = 1;

            InitValuesDoc();
            UpdateTotalsValues();
            //DevValuesRefresh();
        }

       

        private void DisplayDoc(int docNum)
        {   
            
            Doc currentDoc = AllDocs.masterList[docNum-1];

            numCurrentDocNumber.Text = AllDocs.currentDocNumber.ToString();
            stringDocTitle.Text = currentDoc.title;
            txtNumPages.Text = currentDoc.numPages.ToString();
            txtNumFields.Text = currentDoc.numFields.ToString();
            boolNeedWord.IsChecked = currentDoc.isWordFormat;
            boolNeedFast.IsChecked = currentDoc.needFast;
        }

       

        private Doc GatherDocInfo()
        {
            int numPages;
            if (!Int32.TryParse(txtNumPages.Text, out numPages))
            {
                MessageBox.Show("The number of pages must be a whole number. Thank you");
            }

            int numFields;
            if (!Int32.TryParse(txtNumFields.Text, out numFields))
            {
                MessageBox.Show("The number of fields must be a whole number. Thank you");
            }



            bool needFast = boolNeedFast.IsChecked ?? false;

            bool needWord = boolNeedWord.IsChecked ?? false;

            string title = stringDocTitle.Text;

            Doc currentDoc = new Doc(numPages, numFields, needFast, needWord, title);

            return currentDoc;
        }

        public bool DocEmpty()
        {
            bool output = false;
            if(stringDocTitle.Text + txtNumPages.Text + txtNumFields.Text == "") //ignoring data if just checks
            {
                output = true;
            }
            return output;
        }

        
    }
}
