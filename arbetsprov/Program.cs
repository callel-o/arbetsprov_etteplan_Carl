using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace arbetsprov
{
    internal class Program
    {
        /// <summary>
        /// 
        /// Arbetsprov Etteplan lösning av Carl Lidström Olsson
        /// Programmet är uppbyggt i tre delar som främst utgår från strukturen i XML-filen.
        /// 
        /// OBS: jag har ej gjort någon error catching eller liknande och det är ganska enkelt att få error genom att skriva ex fel sökväg. 
        /// Så se till att skriva in rätt sökväg till de två XML dokumenten så funkar det som jag vill. :)
        /// Hoppas detta går bra ändå.
        /// 
        /// 1.Namespace TransUnit inehåller flera klasser och är helt utifrån XML-filens uppbyggnad för att kunna utföra serialization och DeSerialization.
        /// 2.MethodsClass där jag har metoderna som utför serialization och input
        /// 3.Program klassen, där jag använder alla metoder och programmet körs
        /// 
        /// INFO: Jag valde att använda serialization då jag jobbat med det tidigare, även fast det kanske inte är den snabbaste eller mest "clean" lösningen i detta fall.
        /// Men det har en fördel eftersom jag kan arbeta med hela XML filen och ett objekt av det, om något annat element skulle presenteras går det därmed enkelt att ändra.
        ///
        /// </summary>


        static void Main(string[] args)
        {
            MethodsClass methodsClass = new MethodsClass();

           //-----Om man inte vill skriva in filepath i kommandotolken kan man använda nedan variabel och klistra in sökvägen där.
           //string filepath = "C:\\Users\\carll\\Desktop\\Visual Studio\\Etteplan_arbetsprov\\arbetsprov\\sma_gentext.xml";  
            string filepath = methodsClass.SelectFilePath();


            //När filväg är vald serilizeras filen här och förvaras i variabeln DeserializedObject.
            var DeserializedObject = methodsClass.DeserializeFromXml(filepath);
            Console.WriteLine("-----------------------------------");

            //Skapar sedan nytt objekt av Root och ger den all info som serialiserats
            Root newRoot = new Root();
            newRoot = DeserializedObject;

            string filepath2 = methodsClass.SelectFilePath();

            //Därefter skriver man in sin sökväg till den andra XML-filen där infon ska presenteras, 
            //"C:\\Users\\carll\\Desktop\\Visual Studio\\Etteplan_arbetsprov\\arbetsprov\\test.xml"
            methodsClass.SerializeToXml1(filepath2, newRoot);

        }//End of main


    }
}
