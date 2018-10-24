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
using System.Windows.Shapes;

namespace VirtuaDesktop
{
    /// <summary>
    /// Interaction logic for ConfirmCreation.xaml
    /// </summary>
    public partial class ConfirmCreation : Window
    {
        public ConfirmCreation()
        {
            InitializeComponent();
        }

        private void onConfirm(object sender, RoutedEventArgs e)
        {
            DesktopSelection window = new DesktopSelection();
            window.Show();
            Close();
        }
    }
}
