using Network.Shared;

namespace ServicesLib
{
    public class PrintMessage : IPrintMessage
    {
        public void Print(Message message)
        {
            Console.WriteLine($"От {message.NickNameFrom}\n{message.DateTime:F}\n{message.Text}");
        }
    }
}