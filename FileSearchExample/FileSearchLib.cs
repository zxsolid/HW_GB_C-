namespace FileSearchExample
{
    public class FileSearchLib
    {
        public static void SearchFiles(string directory, string fileName)
        {
            string[] files = Directory.GetFiles(directory, fileName, SearchOption.AllDirectories);

            if (files.Length == 0)
            {
                Console.WriteLine("Файлы не найдены.");
                return;
            }

            Console.WriteLine($"Найдено {files.Length} файл(ов):");

            foreach (string file in files)
                Console.WriteLine(file);
            
        }

        public static void SearchTextInFile(string filePath, string searchText)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                    if (line.Contains(searchText))
                        Console.WriteLine($"В файле {filePath} найдено совпадение: {line}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
            }
        }

        public static void SearchFilesWithText(string directory, string extension, string searchText)
        {
            string[] files = Directory.GetFiles(directory, $"*.{extension}", SearchOption.AllDirectories);

            if (files.Length == 0)
            {
                Console.WriteLine($"Файлы с расширением {extension} не найдены.");
                return;
            }

            Console.WriteLine($"Найдено {files.Length} файл(ов) с расширением {extension}:");

            foreach (string file in files)
                SearchTextInFile(file, searchText);
        }
    }
}