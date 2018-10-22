using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public Desktop_Manager desktopManager;
        public DesktopSelection()
        {
            InitializeComponent();
            listView.Items.Clear();
            //We create our desktopManager, and use the list to display our desktops.
            desktopManager = new Desktop_Manager();
            foreach (Desktop desktop in desktopManager.desktops)
            {
                listView.Items.Add(desktop);
            }
            

        }

        private void onEditClick(object sender, RoutedEventArgs e)
        {
            //once we click, we need to open an edit window but have all controls linked to our specific object that we have selected.
            Desktop desktop = (Desktop)listView.SelectedItem;

            //Here we open up the EditWindow, and pass the desktop Object.

            EditWindow editWindow = new EditWindow(this, desktop);
            editWindow.Show();

            
            Console.WriteLine($"Desktop Name: {desktop.Name}");
            Console.WriteLine($"Desktop Path: {desktop.Location}");
            Console.WriteLine($"Desktop IsDefault: {desktop.IsDefault}");
            Console.WriteLine($"Desktop IsFavorite: {desktop.IsFavorite}");
            

        }

        internal void refreshListView()
        {
            listView.Items.Clear();
            foreach (Desktop desktop in desktopManager.desktops)
            {
                listView.Items.Add(desktop);
            }
        }

        private void onUse(object sender, RoutedEventArgs e)
        {
            //When we click on use, we first need to check if we've selected anything

            if (listView.SelectedItem == null)
            {
                //we just do nothing.
            }
            else
            {
                //if we do have an item, we need to select the desktop that was selected, and change the desktop to that.
                DesktopIcons icons = new DesktopIcons();
                Desktop desktop = (Desktop)listView.SelectedItem;
                icons.ToggleDesktopIcons();
                DesktopChanger.Change_Desktop(desktop.Location);
                Wallpaper.Set(new Uri(desktop.Background), Wallpaper.Style.Centered);
                icons.ToggleDesktopIcons();
                //We also close this window.
                Close();
            }
        }


        

        private void onDefaultClick(object sender, RoutedEventArgs e)
        {
            //The user has clicked the default button
            //We move to using the default desktop that's located in our desktopManager
            Desktop desktop = desktopManager.desktops.Where(i => i.IsDefault == true).FirstOrDefault();
            //We hide icons first, to make the change more seemless
            DesktopIcons icons = new DesktopIcons();
            icons.ToggleDesktopIcons();
            DesktopChanger.Change_Desktop(desktop.Location);
            Wallpaper.Set(new Uri(desktop.Background), Wallpaper.Style.Centered);
            icons.ToggleDesktopIcons();
            //We also close this window.
            Close();


        }
    }
}
