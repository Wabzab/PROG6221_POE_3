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
using System.Text.RegularExpressions;

namespace PROG6221_POE_3
{
    /// <summary>
    /// Interaction logic for NumberTextBox.xaml
    /// </summary>
    public partial class NumberTextBox : UserControl
    {

        public string Text
        {
            get { return input.Text; }
            set { input.Text = value; }
        }

        public NumberTextBox()
        {
            InitializeComponent();
        }

        private void ValidateInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (e.Text == "." && input.Text.IndexOf('.') == -1)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = regex.IsMatch(e.Text);
            }
        }
    }
}
