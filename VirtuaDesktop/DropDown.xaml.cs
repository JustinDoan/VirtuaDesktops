using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for DropDown.xaml
    /// </summary>
    public partial class DropDown : Window
    {

        public Desktop_Manager Desktops;
        public DropDown()
        {
           

            InitializeComponent();
            Desktops = new Desktop_Manager();
            foreach (Desktop desktop in Desktops.desktops)
            {
                comboBox.Items.Add(desktop);
            }
            Top = 0;
            Left = SystemParameters.PrimaryScreenWidth - this.Width;

        }

        private void onSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //When we change we update our desktop

            DesktopIcons icons = new DesktopIcons();
            Desktop desktop = (Desktop)comboBox.SelectedItem;
            icons.ToggleDesktopIcons();
            DesktopChanger.Change_Desktop(desktop.Location);
            Wallpaper.Set(new Uri(desktop.Background), Wallpaper.Style.Centered);
            icons.ToggleDesktopIcons();

        }
        private void onQuit(object sender, RoutedEventArgs e) {

            Close();

        }

        private void onUseClick(object sender, RoutedEventArgs e)
        {
            DesktopIcons icons = new DesktopIcons();
            Desktop desktop = (Desktop)comboBox.SelectedItem;
            icons.ToggleDesktopIcons();
            DesktopChanger.Change_Desktop(desktop.Location);
            Wallpaper.Set(new Uri(desktop.Background), Wallpaper.Style.Centered);
            icons.ToggleDesktopIcons();
        }

        private void onEditClick(object sender, RoutedEventArgs e)
        {
            DesktopSelection window = new DesktopSelection();
            window.Show();
            Close();
        }

    }
}
