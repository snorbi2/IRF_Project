using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace CoronaApp
{
    class InputParser
    {
        private readonly List<County> _counties;

        public string InputFilePath { get; set; }

        public InputParser(string filePath)
        {
            _counties = new List<County>();
            InputFilePath = filePath;
        }

        public IEnumerable<County> Parse()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(InputFilePath);

            XmlNode countriesNode = doc.LastChild;
            if (countriesNode.HasChildNodes)
            {
                foreach (XmlNode countryNode in countriesNode.ChildNodes)
                {
                    var county = new County();
                    _counties.Add(county);
                    ReadChildElements(countryNode, county);
                }
            }
            return _counties;
        }

        private void ReadChildElements(XmlNode countryNode, County county)
        {
            foreach (XmlNode childNode in countryNode.ChildNodes)
            {
                if (childNode.Name == "Name")
                {
                    county.Name = childNode.InnerText;
                }
                else if (childNode.Name == "All")
                {
                    county.AllCases = int.Parse(childNode.InnerText);
                }
                else if (childNode.Name == "New")
                {
                    county.NewCases = int.Parse(childNode.InnerText);
                }
                else if (childNode.Name == "Weekly")
                {
                    county.WeeklyCases = int.Parse(childNode.InnerText);
                }
                else if (childNode.Name == "PerCapita")
                {
                    county.PerCapitaCases = int.Parse(childNode.InnerText);
                }
            }
        }
    }
}
