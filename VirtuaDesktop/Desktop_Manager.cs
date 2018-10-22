using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtuaDesktop
{
    

    public class Desktop_Manager
    {
        static string xmlFileLocation = @"Desktops.xml";
        public List<Desktop> desktops = new List<Desktop>();
        DesktopXmlizer _deskXML = new DesktopXmlizer();

        public Desktop_Manager()
        {
            //When we create our Manager Object, we should attempt to get all of the desktops loaded ahead of time.
            desktops = _deskXML.XMLToDesktop(xmlFileLocation);
        }

        public void RefreshDesktops()
        {
            //If we need to refresh our list from our file for some reason.
            desktops = _deskXML.XMLToDesktop(xmlFileLocation);
        }

        public void Save_Desktops()
        {
            //Save our list of desktops to our file.
            _deskXML.DesktopsToXML(desktops);
        }

    }
}
