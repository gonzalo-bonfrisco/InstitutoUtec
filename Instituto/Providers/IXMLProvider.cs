using Instituto.Enums;
using System.Xml.Linq;

namespace Instituto.Providers
{
    public interface IXMLProvider
    {
        XDocument GetDocument(XMLEnum xmlKey);
        void SaveDocument(XDocument documento, XMLEnum xmlKey);
    }
}