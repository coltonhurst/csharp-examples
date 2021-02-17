/*
    This is an example of serializing an object with XML.
    In short, serialization allows us to "store" the state of an object
    for future use.
    We can later "restore" the state of the object easily.

    We have a Car class that has a Name, Gas, and Color.

    After setting these values, we can use the XmlSerializer class
    to serialize the data and the StreamWriter class to write this
    data to a file.

    Then, we can use the XmlSerializer class and the StreamReader
    class to bring the data back in from the file.
*/

using System;
using System.Xml.Serialization;
using System.IO;

namespace serialization_xml
{
    class Program
    {
        static void Main(string[] args)
        {
            // build the Car class
            Car myCar = new Car();
            myCar.Color = Color.Silver;
            myCar.Gas = 10.5;
            myCar.Name = "Jeremiah Thunder";

            // create the XmlSerializer
            XmlSerializer mySerializer = new XmlSerializer(typeof(Car));

            // serialize `myCar` and write it to a file
            StreamWriter myWriter = new StreamWriter("myCarSerialized.xml");
            mySerializer.Serialize(myWriter, myCar);
            myWriter.Close();

            // read in the serialized xml from `myCarSerialized.xml` and store it in `myNewCar`
            StreamReader myReader = new StreamReader("myCarSerialized.xml");
            Car myNewCar = (Car) mySerializer.Deserialize(myReader);
            myReader.Close();

            // print the details of `myNewCar`
            Console.WriteLine("My new car's name is {0}. It is {1} and has {2} gallons of gas in the tank.", myNewCar.Name, myNewCar.Color, myNewCar.Gas);
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
        White,
        Silver
    }
}

/*

This should output: My new car's name is Jeremiah Thunder. It is Silver and has 10.5 gallons of gas in the tank.

`myCarSerialized.xml` should contian:
    
<?xml version="1.0" encoding="utf-8"?>
<Car xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Name>Jeremiah Thunder</Name>
  <Gas>10.5</Gas>
  <Color>Silver</Color>
</Car>

*/