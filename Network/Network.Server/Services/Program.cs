using Network.Server.Services.Classes;
using Network.Server.Services.Interfaces;
using ServicesLib;
using System.Net.Sockets;

namespace Network.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр OurClient с использованием внедрения зависимостей
            IServerCommunication serverCommunication = new ServerCommunication(
                new UdpClient(), new GetSendService(), new PrintMessage());
            OurServer ourServer = new(serverCommunication);
            ourServer.Started();
        }
    }
}