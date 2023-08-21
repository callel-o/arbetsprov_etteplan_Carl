using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;

namespace arbetsprov
{
    internal class MethodsClass
    {
        /// <summary>
        /// 
        /// Klasser som serialize och deserialize till/från XML
        /// Även klass SelectFilePath som hanterar lite user input
        /// 
        /// 
        /// </summary>

        //Metod för att skriva in/kopiera in sökväg, OBS ej fixat så att den inte skapar error.
        //Endast snabb lösning så man kan skriva in den sökväg man har till sin XML-fil
        public string SelectFilePath() 
        {
                string filepath = null;
                Console.WriteLine("Kopiera/skriv in sökväg för XML fil: ");
                filepath = Console.ReadLine();
                return filepath;
        }

        //Metod som Deserialize XML filen, 
        public Root DeserializeFromXml(string filepath) 
        {
            XmlSerializer xmlDeSerializer = new XmlSerializer(typeof(Root)); //Eftersom XML-filen utgår från Root-element är det denna typ jag DeSerializerar.
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                var obj = (Root)xmlDeSerializer.Deserialize(fs); //Deserializerar XMl filen till variabeln obj
                Console.WriteLine("Deserializing ID: 42007");    //bara lite InfoText
                
                //Loopar igenom varje transunit.
                //När loopen hittar den TransUnit med efterfrågat ID så bygger den upp nytt XML dokument med den info som finns tillgänglig i denna unit.
                foreach (Transunit transUnit in obj.File.Body.Transunit)
                {
                    if (transUnit.Id == "42007")
                    {
                        Console.WriteLine(transUnit.Target); //Endast för att visa den text som ska printas
                        Console.ReadLine();

                        //----Skapar ny XML fil utifrån tidigare struktur och lägger endast till den info som behöver vara med-----
                        //----Börjar med hela grunden - sedan lägger jag till den efterfrågade Transuniten-----
                        obj = new Root();
                        obj.File = new File();
                        obj.File.Body = new Body();
                        //obj.File.Body.Group = new Group();
                        obj.File.Body.Transunit = new List<Transunit>();
                        obj.File.Body.Transunit.Add(new Transunit {Target=transUnit.Target, Id=transUnit.Id});                      
                        //------------------------
                        break;
                    }
                }
                return obj;
            }//End of fs

        }


        public void SerializeToXml1(string filepath, Root obj) 
        {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Root));
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, obj); //här tar jag det objekt som returneras i DeserializeMetoden och serialiserar det.
                    Console.WriteLine("Serialization har gjorts till sökväg: " + filepath);
                    Console.ReadLine();
                }
        }

        


    }
}
