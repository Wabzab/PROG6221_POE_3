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
using System.Globalization;
using System.Windows.Shapes;

namespace PROG6221_POE_3
{
    /// <summary>
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        MainWindow main;
        Utilities util = new Utilities();
        List<object> children;

        string vehicelMakeModel = "Vehicle Loan";

        public Page4(MainWindow mainIn)
        {
            InitializeComponent();
            main = mainIn;
            children = util.GetChildren(vehicleDeats, 1);
        }

        private void CalculateVehicleLoan(object sender, RoutedEventArgs e)
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

            double BaseValue = double.Parse(baseValue.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            double Deposit = double.Parse(deposit.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            double Interest = double.Parse(interest.Text, NumberStyles.Any, CultureInfo.InvariantCulture);
            double Premium = double.Parse(premium.Text, NumberStyles.Any, CultureInfo.InvariantCulture);

            double P = BaseValue - (BaseValue * (Deposit / 100.0));
            double i = Interest / 100.0;
            double n = 60 / 12;
            double A = P * (1 + (i * n));

            double vehicleLoan = A / 60;
            double insurance = Premium / 60;
            main.SaveExpense(vehicelMakeModel, vehicleLoan + insurance);
        }

        private void SaveMakeModel(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            vehicelMakeModel = textbox.Text;
        }

        private void HandleYesUnchecked(object sender, RoutedEventArgs e)
        {
            main.btnNext.IsEnabled = true;
            main.RemoveExpense(vehicelMakeModel);

        }

        private void HandleNoUnchecked(object sender, RoutedEventArgs e)
        {
            main.btnNext.IsEnabled = false;
            return;
        }
    }
}
