using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VirtuaDesktop
{
    [XmlRoot("Desktop")]
    public class Desktop
    {
        [XmlElement("IsDefault")]
        public bool IsDefault { get; set; }
        [XmlElement("IsFavorite")]
        public bool IsFavorite { get; set; }
        [XmlElement("Location")]
        public string Location { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }

        public Desktop(string name, string location)
        {
            Name = name;
            Location = location;
        }
        //This is for the XML Serializer
        private Desktop() { }

        public static void Change_Desktop(string newPath)
        {
            //ChangeDesktop.Change_Desktop(newPath);
        }
    }
}
