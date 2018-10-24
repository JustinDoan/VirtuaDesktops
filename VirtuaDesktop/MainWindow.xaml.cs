using Microsoft.Win32;
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

namespace VirtuaDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }

       

        private void openSelection(object sender, RoutedEventArgs e)
        {
            DesktopSelection selectionWindow = new DesktopSelection();
            selectionWindow.Show();
        }

        private void onDropdown(object sender, RoutedEventArgs e)
        {
            DropDown window = new DropDown();
            window.Show();
            Close();
        }
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            Focus();
        }
    }
}
