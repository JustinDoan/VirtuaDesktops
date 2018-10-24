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

    
    public partial class CreateWindow : Window
    {

        string Name;
        string Background;
        string Location;
        DesktopSelection selectionWindow;
        public CreateWindow(DesktopSelection _selectionWindow)
        {
            selectionWindow = _selectionWindow;
            InitializeComponent();
            
        }


        private void onCreate(object sender, RoutedEventArgs e)
        {
            //When the user is ready to create their desktop, we will first check that the essential fields are selected.

            if (textBox.Text == "" || Background == "") {
                //If either of the two essential fields are empty, we need to update our display to tell the user that they need to give us this info.
                Warning.Content = "You must set both a Name and a Path to the folder you wish to become a Desktop.";
                return;
            }


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
                Location = dialog.FileName;
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
                Background = dialog.FileName;
            }
            //Since we've updated our location, we should update the current location label.
            DataContext = "";
            DataContext = clonedDesktop;



        }
    }
}
