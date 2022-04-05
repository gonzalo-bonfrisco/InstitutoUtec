using Instituto.Enums;
using Instituto.Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Instituto.Providers
{
    public class XMLProvider
    {
        private string BasePath = string.Empty;
        private XMLMapper mapper;

        public XMLProvider()
        {
            BasePath = ConfigurationManager.AppSettings["XMLDirection"];
            mapper = new XMLMapper();
        }

        public XDocument GetDocument(XMLEnum xmlKey)
        {

            string uri = $"{BasePath}{ConfigurationManager.AppSettings[mapper.GetKey(xmlKey)]}";

            return XDocument.Load(uri);
        }

    }
}
