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

/* PROG6221 POE Part 3
 * Max Paterson-Jones ST10082168
 * WPF GUI application for the Budget Planner Console application
 * that was developed in parts 1 & 2 of the PROG POE.
 * All the same functionality can be found in this application that
 * can be found in the previous console versions, along with an extra
 * feature for calculating the time to save an amount of money over a
 * specified time.
 */

namespace PROG6221_POE_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // List for storing instances of the various pages used in this application
        object[] pageURI;
        // Variable to track the current page
        int curPage = 0;

        // Generic collection for storing expenses gathered from various pages
        private IDictionary<string, double> expenseValues = new Dictionary<string, double>();

        // Constructor
        public MainWindow()
        {
            InitializeComponent();
            // Instance every page with a reference to this class
            pageURI = new object[] { new Page1(this), new Page2(this), new Page3(this), new Page4(this), new Page5(this), new Page6(this)};
            // Navigate to the first page on startup
            this.Loaded += (s, e) =>
            {
                Main.Navigate(pageURI[curPage], UriKind.Relative);
            };
            btnNext.IsEnabled = false;
        }

        // Interaction Logic for the BACK button to navigate back through pages
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Main.CanGoBack)
            {
                Main.GoBack();
                curPage--;
                btnNext.IsEnabled = true;
            }
        }

        // Interaction Logic for the NEXT button to navigate through pages
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (curPage < pageURI.Length-1)
            {
                curPage++;
                Main.Navigate(pageURI[curPage], UriKind.Relative);
                btnNext.IsEnabled = false;
            }
        }

        // Accessible by each Page's logic to disable or enable the next button
        public void ToggleNextButton(bool state)
        {
            btnNext.IsEnabled = state;
        }

        // Allow for storing an expense or updating a stored expense
        public void SaveExpense(string expenseName, double value)
        {
            if (expenseValues.ContainsKey(expenseName))
            {
                expenseValues[expenseName] = value;
            }
            else
            {
                expenseValues.Add(expenseName, value);
            }
        }

        // Remove a specific expense store
        public void RemoveExpense(string expenseName)
        {
            if (expenseValues.ContainsKey(expenseName))
            {
                expenseValues.Remove(expenseName);
            }
        }

        // Retrieve the expenses
        public IDictionary<string, double> GetExpenses()
        {
            return expenseValues;
        }

    }
}
