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
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {

        MainWindow main;
        Utilities util = new Utilities();
        List<object> childrenRent;
        List<object> childrenBuy;

        public Page3(MainWindow mainIn)
        {
            InitializeComponent();
            main = mainIn;
            childrenRent = util.GetChildren(gridRent, 1);
            childrenBuy = util.GetChildren(gridBuy, 1);
        }

        private void SaveContent(object sender, RoutedEventArgs e)
        {
            NumberTextBox textbox = ((NumberTextBox)sender);
            if (double.TryParse(textbox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
            {
                main.SaveExpense(textbox.Name, double.Parse(textbox.Text, NumberStyles.Any, CultureInfo.InvariantCulture));
            }

            List<object> children;
            if ((bool)rent.IsChecked)
            {
                children = childrenRent;
            } else
            {
                children = childrenBuy;
            }

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
        }

        private void CalculateHomeLoan(object sender, RoutedEventArgs e)
        {
            foreach (object child in childrenBuy)
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

            double BaseValue = double.Parse(baseValue.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            double Deposit = double.Parse(deposit.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            double Interest = double.Parse(interest.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            double Time = double.Parse(time.Text, NumberStyles.Any, CultureInfo.InvariantCulture);

            double P = BaseValue - (BaseValue * (Deposit / 100.0));
            double i = Interest / 100.0;
            double n = Time / 12.0;
            double A = P * (1 + (i * n));

            double homeLoan = A / Time;
            main.SaveExpense("Homeloan", homeLoan);
        }

        private void HandleRentUnchecked(object sender, RoutedEventArgs e)
        {
            main.btnNext.IsEnabled = false;
            foreach (object child in childrenRent)
            {
                if (child.GetType() == typeof(NumberTextBox))
                {
                    NumberTextBox o = ((NumberTextBox)child);
                    main.RemoveExpense(o.Name);
                }
            }
        }

        private void HandleBuyUnchecked(object sender, RoutedEventArgs e)
        {
            main.btnNext.IsEnabled = false;
            main.RemoveExpense("Homeloan");
            return;
        }
    }
}
