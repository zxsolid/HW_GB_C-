using Network.Server.Services.Interfaces;
using ServicesLib;
using System.Net.Sockets;
using System.Net;
using Network.Shared;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Network.Server.Services.Classes

{
    public class ServerCommunication : IServerCommunication
    {
        private readonly UdpClient _udpClient;
        private readonly IGetSend _getSendService;
        private IPEndPoint? _iPEndPoint;
        private readonly IPrintMessage _printMessage;
        private bool _isServerRunning;

        private const int BufferSize = 8192; // Увеличиваем размер буфера приема

        public ServerCommunication(UdpClient udpClient, IGetSend getSendService, IPrintMessage printMessage)
        {
            _udpClient = udpClient;
            _getSendService = getSendService;
            _printMessage = printMessage;
            _udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 12345));
            _iPEndPoint = (IPEndPoint)_udpClient.Client.LocalEndPoint;
            _isServerRunning = true;
        }

        public void Start()
        {
            Console.WriteLine("Сервер запущен. Введите 'Exit' для выхода.");

            LoopClients();

            Console.Write("Cервер остановлен.");
        }

        public void Stop()
        {
            _udpClient.Close();
        }

        private async void LoopClients()
        {
            while (_isServerRunning)
            {
                var thread = new Thread(async () => await HandleClientAsync()) { IsBackground = true };
                thread.Start();
                thread.Join();
                _isServerRunning = await ServerCloseAsync();
            }
        }

        private async Task HandleClientAsync()
        {
            byte[] buffer = new byte[BufferSize];

            try
            {
                var receiveResult = await _udpClient.ReceiveAsync();
                buffer = receiveResult.Buffer;
                _iPEndPoint = receiveResult.RemoteEndPoint as IPEndPoint; // Сохраняем адрес клиента
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Ошибка при получении данных от клиента: {ex.Message}");
                return;
            }

            var message = await _getSendService.FormingMessageForGet(buffer);

            if (message is null)
            {
                Console.WriteLine("Ошибка обработки сообщения.");
                return;
            }

            _printMessage.Print(message);

            await SendMessageAsync(new string[3] { "Сообщение принято сервером", "Server", message.NickNameTo.ToString() });
        }

        private async Task<bool> SendMessageAsync(string[] parts)
        {
            Message message = new Message(parts[0], new UserEntity(parts[1]), new UserEntity(parts[2]));

            var sendMessage = await _getSendService.FormingMessageForSend(message);

            if (sendMessage is null)
                return await Task.FromResult(false);

            try
            {
                if (_iPEndPoint is not null && !_iPEndPoint.Address.ToString().Equals("0.0.0.0"))
                    await _udpClient.SendAsync(sendMessage.Data, sendMessage.Data.Length, _iPEndPoint);
            }
            catch (SocketException ex)
            {
                Console.WriteLine($"Ошибка при отправке сообщения клиенту: {ex.Message}");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }

        private async Task<bool> ServerCloseAsync()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    await SendMessageAsync(new string[3] { "Сервер остановлен", "Server", "Всем" });
                    return await Task.FromResult(false);
                }
            }
            return await Task.FromResult(true);
        }
    }
}