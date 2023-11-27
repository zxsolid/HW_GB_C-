using JsonXmlLib;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string jsonInput = File.ReadAllText("input.json");

            string xmlOutput = jsonInput.ConvertJsonToXml();

            File.WriteAllText("output.xml", xmlOutput);

            Console.WriteLine("Конвертация JSON в XML завершена.");
            Console.WriteLine(xmlOutput);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }

        Console.ReadLine();
    }
}