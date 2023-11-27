namespace CalculatorEvent
{
    public interface ICalc
    {
        double Result { get; set; }
        public Stack<double> LastResult { get; set; }

        public event EventHandler<EventArgs> MyEventHandler;

        void Divide(double x);
        void Multy(double x);
        void Sum(double x);
        void Sub(double x);
        void CancelLast();
    }
}