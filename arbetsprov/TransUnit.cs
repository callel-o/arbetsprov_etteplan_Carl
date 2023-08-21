using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace arbetsprov
{
    /// <summary>
    /// 
    /// Här förvaras alla klasser som tillhör XML-filen.
    /// trans-unit elementet är en List
    /// 
    /// </summary>

    //----------Group element-----------
    [XmlRoot(ElementName = "group")]
    public class Group
    {

        [XmlAttribute(AttributeName = "resname")]
        public string Resname { get; set; }

        [XmlAttribute(AttributeName = "restype")]
        public string Restype { get; set; }

    }

    //----------Trans-Unit element-----------
    [XmlRoot(ElementName = "trans-unit")]
    public class Transunit
    {

        [XmlElement(ElementName = "source")]
        public string Source { get; set; }

        [XmlElement(ElementName = "target")]
        public string Target { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "restype")]
        public string Restype { get; set; }

    }

    //------Body element------
    [XmlRoot(ElementName = "body")]
    public class Body
    {

        [XmlElement(ElementName = "group")]
        public Group Group { get; set; }

        [XmlElement(ElementName = "trans-unit")]
        public List<Transunit> Transunit { get; set; }
    }

    //-----File element------
    [XmlRoot(ElementName = "file")]
    public class File
    {
        [XmlElement(ElementName = "body")]
        public Body Body { get; set; } //EV göra denna till list

        [XmlAttribute(AttributeName = "source-language")] 
        public string Sourcelanguage { get; set; }

        [XmlAttribute(AttributeName = "target-language")]
        public string Targetlanguage { get; set; }
    }

    //----------Root element-----------
    [XmlRoot(ElementName = "root")]
    public class Root
    {
        [XmlElement(ElementName = "file")]
        public File File { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }





}
