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
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.Win32;

namespace VirtuaDesktop
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>

    
    public partial class EditWindow : Window
    {

        Desktop originalDesktop;
        Desktop clonedDesktop;
        DesktopSelection selectionWindow;
        DropDown dropDownWindow;
        public EditWindow(DesktopSelection _selectionWindow, Desktop _desktop)
        {
            selectionWindow = _selectionWindow;
            originalDesktop = _desktop;
            clonedDesktop = new Desktop(_desktop.Name, _desktop.Location) { IsDefault = _desktop.IsDefault, IsFavorite = _desktop.IsFavorite, Background = _desktop.Background };
            DataContext = clonedDesktop;
            InitializeComponent();
            
        }
        

        private void onApply(object sender, RoutedEventArgs e)
        {
            //when we apply our changes, since we are using our cloned desktop, we need to apply any changes that were made.

            originalDesktop.Name = clonedDesktop.Name;
            originalDesktop.Location = clonedDesktop.Location;
            originalDesktop.Background = clonedDesktop.Background;
            originalDesktop.IsFavorite = clonedDesktop.IsFavorite;
            originalDesktop.IsDefault = clonedDesktop.IsDefault;

            //We then want to save any changes to our xml file, so we use our previous window which contains the Desktopmanager to do so.

            selectionWindow.desktopManager.Save_Desktops();
            selectionWindow.refreshListView();

            

            //our correct ref gets updated and we then close the window
            Close();

        }

        private void onSelect(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                clonedDesktop.Location = dialog.FileName;
            }
            //Since we've updated our location, we should update the current location label.
            DataContext = "";
            DataContext = clonedDesktop;
        }

        private void onImageSelect(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.Filter = "Image files (*.jpg,*.jpeg,*.jpe,*.jfif,*.png)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png";
            if (dialog.ShowDialog() == true)
            {
                clonedDesktop.Background = dialog.FileName;
            }
            //Since we've updated our location, we should update the current location label.
            DataContext = "";
            DataContext = clonedDesktop;



        }
    }
}
