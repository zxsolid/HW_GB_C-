namespace CalculatorEvent
{
    internal class Calc : ICalc, IDoubleTryPars
    {
        public double Result { get; set; } = 0D;
        public Stack<double> LastResult { get; set; } = new Stack<double>();

        public event EventHandler<EventArgs> MyEventHandler;

        private void PrintResult() { MyEventHandler?.Invoke(this, new EventArgs()); }

        public void Divide(double x)
        {
            if (x == 0) throw new ArgumentException("Делитель не может быть равен нулю.");

            if (Result != 0) Result /= x;
            else Result = x;

            if (Result < 0) throw new InvalidOperationException("Сумма не может быть отрицательной.");

            PrintResult();
            LastResult.Push(Result);
        }

        public void Multy(double x)
        {
            Result *= x;
            PrintResult();
            LastResult.Push(Result);
        }

        public void Sub(double x)
        {
            Result -= x;

            if (Result < 0) throw new InvalidOperationException("Сумма не может быть отрицательной.");

            PrintResult();
            LastResult.Push(Result);
        }

        public void Sum(double x)
        {
            Result += x;

            if (Result < 0) throw new InvalidOperationException("Сумма не может быть отрицательной.");

            PrintResult();
            LastResult.Push(Result);
        }

        public void CancelLast()
        {
            if (LastResult.TryPop(out double res))
            {
                Result = res;
                Console.WriteLine("Последнее действие отменено. Результат равен: ");
                PrintResult();
            }
            else Console.WriteLine("Невозможно отменить последнее действие");

        }

        public string DoubleTryPars(string str, out double num)
        {
            num = 0;
            try
            {
                num = Convert.ToDouble(str);
            }
            catch (FormatException ex)
            {
                return ex.Message;
            }
            return string.Empty;
        }
    }
}