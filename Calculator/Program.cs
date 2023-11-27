/*
    * 1. Спроектируйте интерфейс калькулятора, поддерживающего простые арифметические действия, 
         хранящего результат и также способного выводить информацию о результате при помощи события.

    * 2. Арифметические методы должны выполняться как обычно а метод CancelLast должен отменять последнее действие. 
         При этом метод может отменить последовательно все действия вплоть до самого последнего.

    * 3. Доработайте программу калькулятор реализовав выбор действий и вывод результатов на экран 
         в цикле так чтобы калькулятор мог работать до тех пор пока пользователь не нажмет отмена 
         или введёт пустую строку.
    
    * 4. Доработайте класс калькулятора способным работать как с целочисленными так 
         и с дробными числами. (возможно стоит задействовать перегрузку операций).
    
    * 5. Заменить Convert.ToDouble на собственный DoubleTryPars и обрабатываем ошибку
    
    * 6. Проверить что введенное число небыло отрицательное (вывести ошибку Exeption , отловить Catch)4
    
    * 7. Сумма не может быть отрицательной (при делении и вычитании)
*/

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace CalculatorEvent;

class Program
{

    static void Main(string[] args)
    {
        var calc = new Calc();
        calc.MyEventHandler += Calc_MyEventHandler;

        // Выводим приветствие и инструкцию пользователю
        Console.WriteLine("Добро пожаловать в калькулятор! Введите число и действие через пробел (+, -, *, /),\nлибо введите 'отмена' или пустую строку для выхода.");

        string input;
        do
        {
            Console.Write("Введите число и действие: ");
            input = Console.ReadLine();

            if (input.ToLower() == "отмена" || string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Работа калькулятора завершена.");
                break;
            }

            // Парсим введенную строку
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                Console.WriteLine("Неверный формат ввода. Попробуйте снова.");
                continue;
            }

            if (!string.IsNullOrEmpty(calc.DoubleTryPars(parts[0], out double number)))
            {
                Console.WriteLine("Неверный формат числа. Попробуйте снова.");
                continue;
            }

            switch (parts[1])
            {
                case "+":
                    calc.Sum(number);
                    break;
                case "-":
                    calc.Sub(number);
                    break;
                case "*":
                    calc.Multy(number);
                    break;
                case "/":
                    try
                    {
                        calc.Divide(number);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный оператор. Попробуйте снова.");
                    break;
            }

        } while (true);
    }

    private static void Calc_MyEventHandler(object? sender, EventArgs e)
    {
        if (sender is Calc calc)
            Console.WriteLine(calc.Result);
    }
}