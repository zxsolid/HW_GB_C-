using Network.Client.Services.Classes;
using Network.Client.Services.Interfaces;
using ServicesLib;
using System.Net.Sockets;

namespace Network.Client;

internal class Program
{
    static void Main(string[] args)
    {
        // Выводим приветствие и инструкцию пользователю
        Console.WriteLine("Введите через запятую:\nТекст сообщения, Ваш NickName и NickName кому хотите отправить сообщение: ");

        // Создаем экземпляр OurClient с использованием внедрения зависимостей
        IClientCommunication clientCommunication = new ClientCommunication(
            new UdpClient(), new GetSendService(), new PrintMessage());
        OurClient ourClient = new(clientCommunication);
        ourClient.Start();
    }
}