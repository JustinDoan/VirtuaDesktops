using Microsoft.Win32;
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
    /// Interaction logic for NewXMLFile.xaml
    /// </summary>
    public partial class NewXMLFile : Window
    {
        //This window pops up if there is a missing xml file, and the user needs to decide what they want to do about that.
        public NewXMLFile()
        {
            InitializeComponent();
        }

        private void onCreateXMLFile(object sender, RoutedEventArgs e)
        {
            //We need to create a new XML File. Along with the Default Desktop saved to it.
            Desktop defaultDesktop = new Desktop("Default", Environment.GetFolderPath(Environment.SpecialFolder.Desktop)) {IsDefault = true};
            Desktop_Manager desktops = new Desktop_Manager();
            desktops.desktops.Add(defaultDesktop);
            desktops.Save_Desktops();
            //we can now close out this window and display our confirmation window.
            ConfirmCreation window = new ConfirmCreation();
            window.Show();
            Close();


        }
    }
}
