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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        MainWindow main;
        Utilities util = new Utilities();
        List<object> children;

        public Page2(MainWindow mainIn)
        {
            InitializeComponent();
            main = mainIn;
            children = util.GetChildren(stckPnl, 1);
        }

        private void SaveContent(object sender, RoutedEventArgs e)
        {
            NumberTextBox textbox = ((NumberTextBox)sender);
            if (double.TryParse(textbox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
            {
                main.SaveExpense(textbox.Name, double.Parse(textbox.Text, NumberStyles.Any, CultureInfo.InvariantCulture));
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
    }
}
