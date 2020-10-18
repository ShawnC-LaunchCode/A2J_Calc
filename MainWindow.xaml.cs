﻿using System;
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

            InitValues();

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void InitValues()
        {
            //Init starting values
            txtDocNumber.Text = (AllDocs.masterList.Count() + 1).ToString();
            txtDocNumber.IsReadOnly = true;


            txtNumPages.Text = "";
            txtNumRepeated.Text = "";

            txtNumFields.Text = "";
            boolNeedFast.IsChecked = false;
            boolNeedWord.IsChecked = false;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
           //data validation and object creation
            
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

            int numRepeated;
            if (!Int32.TryParse(txtNumRepeated.Text, out numRepeated))
            {
                MessageBox.Show("The number of fields repeated must be a whole number. Thank you");
            }

            bool needFast = boolNeedFast.IsChecked ?? false;

            bool needWord = boolNeedWord.IsChecked ?? false;

            Doc currentDoc = new Doc(numPages, numFields, numRepeated, needFast, needWord);

            //MessageBox.Show(currentDoc.ToString());
            AllDocs.masterList.Add(currentDoc);

            InitValues();

            
        }
    }
}
