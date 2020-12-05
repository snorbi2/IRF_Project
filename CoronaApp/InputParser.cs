using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoronaApp
{
    class InputParser
    {
        private readonly List<County> _counties;

        public string FilePath { get; set; }

        public InputParser(string filePath)
        {
            FilePath = filePath;
        }

        public IEnumerable<County> Parse()
        {
            XmlTextReader reader = new XmlTextReader(FilePath);
            while (reader.Read())
            {
                County county = null;
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Debug.WriteLine($"<{reader.Name}>");
                        if (reader.Name == "County")
                            county = new County();
                        break;
                    case XmlNodeType.Text:
                        Debug.WriteLine($"{reader.Value}");
                        if (reader.Value == "Name")
                            county.Name = reader.Value;
                        if (reader.Value == "All")
                            county.AllCases = int.Parse(reader.Value);
                        if (reader.Value == "New")
                            county.NewCases = int.Parse(reader.Value);
                        if (reader.Value == "Weekly")
                            county.WeeklyCases = int.Parse(reader.Value);
                        if (reader.Value == "PerCapita")
                            county.PerCapitaCases = int.Parse(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Debug.WriteLine($"</{reader.Name}>");
                        if (reader.Name == "County")
                            _counties.Add(county);
                        break;
                }
            }
            return _counties;
        }
    }
}
