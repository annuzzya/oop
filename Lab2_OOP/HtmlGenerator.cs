using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace DormitoryApp
{
    public class HtmlGenerator
    {
        public void GenerateHtml(List<Resident> residents, string xslPath, string outputPath)
        {
            var serializer = new XmlSerializer(typeof(List<Resident>));
            var stringWriter = new StringWriter();
            using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
            {
                serializer.Serialize(xmlWriter, residents);
            }
            string xmlResults = stringWriter.ToString();

            using (var stringReader = new StringReader(xmlResults))
            using (var xmlReader = XmlReader.Create(stringReader))
            {

                var xslt = new XslCompiledTransform();
                xslt.Load(xslPath);

                using (var xmlOutputWriter = XmlWriter.Create(outputPath, new XmlWriterSettings { Indent = true }))
                {

                    xslt.Transform(xmlReader, xmlOutputWriter);
                }
            }
        }
    }
}
