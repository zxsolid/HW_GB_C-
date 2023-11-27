using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml;

namespace JsonXmlLib
{
    public static class JsonXml
    {
        public static string ConvertJsonToXml(this string json)
        {
            try
            {
                XmlDocument? xmlDoc = JsonConvert.DeserializeXmlNode(json, "root", true);
                XDocument xDoc = XDocument.Parse(xmlDoc.OuterXml);
                return xDoc.ToString();
            }
            catch 
            {
                return string.Empty;
            }
           
        }
    }
}