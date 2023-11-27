using ReflectionTaksExtension.Classes;
using ReflectionTaksExtension.Interfaces;

namespace ReflectionTaks;

class Program
{
    static void Main(string[] args)
    {
        MyClass myClass = new MyClass();
        ISerializationHelper serializationHelper = new SerializationHelper();

        string serializedData = serializationHelper.ObjectToString(myClass);
        Console.WriteLine("Serialized data: " + serializedData);

        serializationHelper.StringToObject(myClass, serializedData);
        Console.WriteLine("Deserialized value of I: " + myClass.I);

        Console.ReadLine();
    }
}