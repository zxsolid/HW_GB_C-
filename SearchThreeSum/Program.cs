/*
     * Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
     * Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.
*/

namespace SearchThreeSum;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 4, 2, 7, 3, 9, 6 };
        int targetSum = 10;

        numbers.FindThreeNumbers(targetSum).ToList().ForEach(Console.WriteLine);
    }
}