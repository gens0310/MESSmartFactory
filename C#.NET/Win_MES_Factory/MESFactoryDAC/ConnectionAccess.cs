using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MESFactoryDAC
{
    public abstract class ConnectionAccess
    {

        protected string ConnectionString
        {
            get
            {
                return GetXmlText("MyDB");
            }
        }

        public static XmlDocument LoadXml()
        {
            XmlDocument configXml = new XmlDocument();
            configXml.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/Sample_DEV.xml");

            return configXml;
        }

        public static string GetXmlText(string key)
        {
            string str = "";
            XmlDocument configXml = LoadXml();
            XmlNodeList addNodes = configXml.SelectNodes("configuration/settings/add");

            foreach (XmlNode xmlNode in addNodes)
            {
                if (xmlNode.Attributes["key"].InnerText == key)
                {
                    str = ((XmlCDataSection)xmlNode.ChildNodes[0]).InnerText;
                    break;
                }
            }

            return str;
        }


    }

}
