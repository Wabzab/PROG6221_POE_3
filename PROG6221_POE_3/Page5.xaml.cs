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
using System.Globalization;

namespace PROG6221_POE_3
{
    /// <summary>
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        // Logic for storing instanced objects and filling them out in the constructor
        MainWindow main;
        Utilities util = new Utilities();
        List<object> children;

        public Page5(MainWindow mainIn)
        {
            InitializeComponent();
            main = mainIn;
            children = util.GetChildren(savingDeats, 1);
        }

        // Calculate the amount of money to save each month to reach the specified goal in the specified time
        private void CalculateMonthlySaving(object sender, RoutedEventArgs e)
        {
            foreach (object child in children)
            {
                if (child.GetType() == typeof(NumberTextBox))
                {
                    NumberTextBox o = ((NumberTextBox)child);
                    if (!double.TryParse(o.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                    {
                        main.btnNext.IsEnabled = false;
                        return;
                    }
                }
            }
            main.btnNext.IsEnabled = true;

            double BaseValue = double.Parse(saving.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            double Time = double.Parse(months.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            double Interest = double.Parse(interest.Text, NumberStyles.Any, CultureInfo.InvariantCulture);

            double P = BaseValue;
            double i = Interest / 100.0;
            double n = Time;
            double A = P * (1 + (i * n));

            double monthlySavings = A / Time;
            main.SaveExpense("Savings", monthlySavings);
        }

        // Logic for 'Yes' button being unchecked
        private void HandleYesUnchecked(object sender, RoutedEventArgs e)
        {
            main.btnNext.IsEnabled = true;
            main.RemoveExpense("Savings");

        }

        // Logic for 'No' button being unchecked
        private void HandleNoUnchecked(object sender, RoutedEventArgs e)
        {
            main.btnNext.IsEnabled = false;
            return;
        }
    }
}
