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
        int curPage = 0;

        public string words = "something";

        public MainWindow()
        {
            InitializeComponent();
            pageURI = new object[] { new Page1(this), new Page2(this) };
            this.Loaded += (s, e) =>
            {
                Main.Navigate(pageURI[0], UriKind.Relative);
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Main.CanGoBack)
            {
                Main.GoBack();
                curPage--;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (curPage < pageURI.Length-1)
            {
                curPage++;
                Main.Navigate(pageURI[curPage], UriKind.Relative);
            }
        }
    }
}
