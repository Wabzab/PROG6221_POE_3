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

namespace PROG6221_POE_3
{
    /// <summary>
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        // Logic for storing instanced objects and filling them out in the constructor
        MainWindow main;

        public Page6(MainWindow mainIn)
        {
            InitializeComponent();
            main = mainIn;
        }

        // Logic for the 'GenerateReport' button that generates a report with the expense values in descending order
        private void GenerateReport(object sender, RoutedEventArgs e)
        {
            string report = "";
            IDictionary<string, double> expenseValues = main.GetExpenses();

            report += "Income:\t" + expenseValues["Income"] + "\n";
            report += "Tax:\t" + expenseValues["Tax"] + "\n";
            expenseValues.Remove("Income");
            expenseValues.Remove("Tax");


            report += "Expenses\n";
            var sortedValues = from entry in expenseValues orderby entry.Value descending select entry;
            expenseValues = sortedValues.ToDictionary(x => x.Key, x => x.Value);

            foreach (string key in expenseValues.Keys)
            {
                report += (key + ":\t" + expenseValues[key] + "\n");
            }

            reportBlock.Text = report;
        }
    }
}
