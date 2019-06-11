using System;
using System.Xml.Serialization;
using System.IO;

namespace SerializeTester
{
    public class XMLSerializationExample
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Color = Color.Red;
            myCar.Gas = 10.5;
            myCar.Name = "Eugine";

            XmlSerializer mySerializer = new XmlSerializer(typeof(Car));
            StreamWriter myWriter = new StreamWriter("myCarSerialized.xml");
            mySerializer.Serialize(myWriter, myCar);
            myWriter.Close();
        }
    }

    public class Car
    {
        public string Name { get; set; }
        public double Gas { get; set; }
        public Color Color { get; set; }
    }

    public enum Color
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet,
        Brown,
        Black,
        White
    }
}

/*

Output:
    
<?xml version="1.0" encoding="utf-8"?>
<Car xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Name>Eugine</Name>
  <Gas>10.5</Gas>
  <Color>Red</Color>
</Car>

*/