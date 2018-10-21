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
    /// Interaction logic for DesktopSelection.xaml
    /// </summary>
    public partial class DesktopSelection : Window
    {
        public DesktopSelection()
        {
            InitializeComponent();
            listView.Items.Clear();
            DesktopXmlizer desktopXmlizer = new DesktopXmlizer();
            List<Desktop> desktops = desktopXmlizer.XMLToDesktop("Desktops.xml");
            foreach (Desktop desktop in desktops)
            {
                listView.Items.Add(desktop);
            }
            

        }

        private void onEditClick(object sender, RoutedEventArgs e)
        {
            //once we click, we need to open an edit window but have all controls linked to our specific object that we have selected.
            Console.WriteLine($"Amount of Desktops: {listView.Items.Count}");
            Desktop desktop = (Desktop)listView.SelectedItem;
            Console.WriteLine($"Desktop Name: {desktop.Name}");
            Console.WriteLine($"Desktop Path: {desktop.Location}");
            Console.WriteLine($"Desktop IsDefault: {desktop.IsDefault}");
            Console.WriteLine($"Desktop IsFavorite: {desktop.IsFavorite}");

        }

        
    }
}
