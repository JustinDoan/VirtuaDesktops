using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtuaDesktop
{
    class DesktopXmlizer
    {


        public bool DesktopsToXML(List<Desktop> desktops)
        {

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(desktops.GetType());
            x.Serialize(File.Create("Desktops.xml"), desktops);
            return true;

        }

        public List<Desktop> XMLToDesktop(string path)
        {
            List<Desktop> desktops = new List<Desktop>();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(desktops.GetType());
            try
            {
                using (FileStream stream = File.Open(path, FileMode.Open))
                {
                    desktops = (List<Desktop>)x.Deserialize(stream);
                }
            }
            catch (FileNotFoundException)
            {
                //There is no file, so we need to handle this gracefully. 
                //We just return an empty list, and handle this in the backend of the window.
                return desktops;
            }
            catch (IOException)
            {
                //If the file is in use, then we just pass back an empty list.
                return desktops;
            }
            return desktops;
        }


    }
}
