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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        object[] pageURI;
        int curPage = 3;

        private IDictionary<string, double> expenseValues = new Dictionary<string, double>();

        public MainWindow()
        {
            InitializeComponent();
            pageURI = new object[] { new Page1(this), new Page2(this), new Page3(this), new Page4(this)};
            this.Loaded += (s, e) =>
            {
                Main.Navigate(pageURI[curPage], UriKind.Relative);
            };
            btnNext.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Main.CanGoBack)
            {
                Main.GoBack();
                curPage--;
                btnNext.IsEnabled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (curPage < pageURI.Length-1)
            {
                curPage++;
                Main.Navigate(pageURI[curPage], UriKind.Relative);
                btnNext.IsEnabled = false;
            }
        }

        public void ToggleNextButton(bool state)
        {
            btnNext.IsEnabled = state;
        }

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

        public void RemoveExpense(string expenseName)
        {
            if (expenseValues.ContainsKey(expenseName))
            {
                expenseValues.Remove(expenseName);
            }
        }

    }
}
